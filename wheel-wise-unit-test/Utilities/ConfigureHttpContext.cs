using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using wheel_wise.Controllers;
using wheel_wise.Model;

namespace wheel_wise_unit_test.Utilities;

public static class ConfigureHttpContext
{
    public static IdentityUser IdentityUserGoodContext(UserController userController)
    {
        // Arrange
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, "test@test")
        }));
        userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };
        return new IdentityUser { Email = "test@test" };
    }
    
    public static User UserGoodContext(UserController userController)
    {
        // Arrange
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, "test@test")
        }));
        userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };
        return new User {IdentityUser = new IdentityUser { Email = "test@test" } };
    }
    
    public static IdentityUser IdentityUserBadContext(UserController userController)
    {
        // Arrange
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, "test@test")
        }));
        userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };
        return new IdentityUser { Email = "atest@test" };
    }
    
    public static User UserBadContext(UserController userController)
    {
        // Arrange
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, "test@test")
        }));
        userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };
        return new User {IdentityUser = new IdentityUser { Email = "atest@test" } };
    }
}