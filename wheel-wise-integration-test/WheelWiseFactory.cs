using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using wheel_wise.Data;
using wheel_wise.Model;
using Xunit.Abstractions;

namespace wheel_wise_integration_test;

public class WheelWiseFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<WheelWiseContext>));

            if (dbContextDescriptor != null)
            {
                services.Remove(dbContextDescriptor);
            }

            var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            services.AddDbContext<WheelWiseContext>(options =>
            {
                options.UseInMemoryDatabase("testDb1");
                options.UseInternalServiceProvider(serviceProvider);
            });

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            using var appContext = scope.ServiceProvider.GetRequiredService<WheelWiseContext>();
            appContext.Database.EnsureCreated();

            SeedUsersData(appContext);
            SeedAdvertisementData(appContext);

        });
    }

    private void SeedAdvertisementData(WheelWiseContext context)
    {
        Transmission transmission = new Transmission() { Name = "Automatic" };
        context.Transmissions.Add(transmission);
        context.SaveChanges();
        
        FuelType fuelType = new FuelType() { Name = "Petrol" };
        context.FuelTypes.Add(fuelType);
        context.SaveChanges();
        
        Equipment equipment = new Equipment() {  Name = "AC", Type = "Comfort" };
        context.Equipments.Add(equipment);
        context.SaveChanges();
        
        Color color = new Color() {  Name = "Black" };
        context.Colors.Add(color);
        context.SaveChanges();
        
        CarType carType = new CarType() {  Brand = "Toyota", Model = "Corolla" };
        context.CarTypes.Add(carType);
        context.SaveChanges();
        
        Car car = new Car()
        {
            CarTypeId = 1, ColorId = 1, Equipments = new List<Equipment>() { equipment }, FuelTypeId = 1,
            TransmissionId = 1
        };
        context.Cars.Add(car);
        context.SaveChanges();
        
        var userManager = context.GetService<UserManager<IdentityUser>>();
        var identityUserAdmin = userManager.FindByEmailAsync("admin@admin.com").Result;
        if (identityUserAdmin != null)
        {
            User admin = new User
            {
                IdentityUser = identityUserAdmin, 
                ZipCode = 0,
            };
            if (identityUserAdmin.UserName is not null)
            {
                admin.UserName = identityUserAdmin.UserName;
            }
            if (identityUserAdmin.Email is not null)
            {
                admin.Email = identityUserAdmin.Email;
            }
            context.Users.Add(admin);
            context.SaveChanges();
        }
        
        var identityUserUser = userManager.FindByEmailAsync("user@user.com").Result;
        if (identityUserUser != null)
        {
            User user = new User
            {
                IdentityUser = identityUserUser, 
                ZipCode = 1000,
            };
            if (identityUserUser.UserName is not null)
            {
                user.UserName = identityUserUser.UserName;
            }
            if (identityUserUser.Email is not null)
            {
                user.Email = identityUserUser.Email;
            }
            context.Users.Add(user);
            context.SaveChanges();
        }

        Advertisement ad = new Advertisement()
        {
            CarId = 1, Description = "Description", Highlighted = false, Title = "Title",
            CreatedAt = DateTime.Now, UserId = 1
        };
        context.Advertisements.Add(ad);
        context.SaveChanges();
        
    }

    private void SeedUsersData(WheelWiseContext context)
    {
        // Create roles if they don't exist
        var roleManager = context.GetService<RoleManager<IdentityRole>>();
        var configuration = context.GetService<IConfiguration>();
        var adminRoleName = configuration?["RoleNames:Admin"];
        var userRoleName = configuration?["RoleNames:User"];

        if (roleManager != null && adminRoleName != null && userRoleName != null)
        {
            if (!roleManager.Roles.Any(r => r.Name == adminRoleName))
            {
                roleManager.CreateAsync(new IdentityRole(adminRoleName)).Wait();
            }

            if (!roleManager.Roles.Any(r => r.Name == userRoleName))
            {
                roleManager.CreateAsync(new IdentityRole(userRoleName)).Wait();
            }
        }

        // Create admin user if it doesn't exist
        var userManager = context.GetService<UserManager<IdentityUser>>();
        var adminEmail = "admin@admin.com";

        if (userManager != null && adminRoleName != null)
        {
            if (userManager.FindByEmailAsync(adminEmail).Result == null)
            {
                var adminUser = new IdentityUser
                {
                    UserName = "admin",
                    Email = adminEmail
                };

                var result = userManager.CreateAsync(adminUser, "admin123").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(adminUser, adminRoleName).Wait();
                }
            }
        }
        
        var userEmail = "user@user.com";
        if (userManager != null && userRoleName != null)
        {
            if (userManager.FindByEmailAsync(userEmail).Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "user",
                    Email = userEmail
                };

                var result = userManager.CreateAsync(user, "user123").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, userRoleName).Wait();
                }
            }
        }
    }
}