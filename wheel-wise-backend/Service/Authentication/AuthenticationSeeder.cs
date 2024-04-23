using Microsoft.AspNetCore.Identity;

namespace wheel_wise.Service.Authentication;

public class AuthenticationSeeder
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthenticationSeeder(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
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
            }
        }
    }    
}