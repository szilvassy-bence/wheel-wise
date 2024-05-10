using Microsoft.AspNetCore.Identity;
using wheel_wise.Data;
using wheel_wise.Model;
namespace wheel_wise.Service.Authentication;

public class AuthenticationSeeder
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly WheelWiseContext _context;

    public AuthenticationSeeder(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, WheelWiseContext context)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _context = context;
    }

    public void AddRoles()
    {
        var tAdmin = CreateAdminRole(_roleManager);
        tAdmin.Wait();
        var tUser = CreateUserRole(_roleManager);
        tUser.Wait();
    }

    public void AddAdmin()
    {
        var tAdmin = CreateAdminIfNotExists(_userManager);
        tAdmin.Wait();
    }


    private async Task CreateUserRole(RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole("User"));
    }

    private async Task CreateAdminRole(RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }
    
    private async Task CreateAdminIfNotExists(UserManager<IdentityUser> userManager)
    {
        var adminInDb = await userManager.FindByEmailAsync("admin@admin.com");
        if (adminInDb == null)
        {
            var admin = new IdentityUser { UserName = "admin", Email = "admin@admin.com" };
            var adminCreated = await userManager.CreateAsync(admin, "admin123");
            if (adminCreated.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
                _context.Users.Add(new User { IdentityUser = admin, Email = admin.Email, UserName = admin.UserName, ZipCode = 0, Advertisements = new List<Advertisement>(), FavoriteAdvertisements = new List<Advertisement>()});
                await _context.SaveChangesAsync();
            }
        }
    }    
}