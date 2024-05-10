using Microsoft.AspNetCore.Identity;
using wheel_wise.Data;
using wheel_wise.Model;

namespace wheel_wise.Service.Authentication;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly WheelWiseContext _dbContext;

    public AuthService(UserManager<IdentityUser> userManager, ITokenService tokenService, WheelWiseContext dbContext)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _dbContext = dbContext;
    }


    public async Task<AuthResult> RegisterAsync(string email, string userName, string password, int? zipCode, string role)
    {
        var user = new IdentityUser { Email = email, UserName = userName, TwoFactorEnabled = false };
        
        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            return FailedRegistration(result, email, userName);
        }
        
        await _userManager.AddToRoleAsync(user, role);
        
        var registeringUser = await _userManager.FindByEmailAsync(email);
        _dbContext.Users.Add(new User { IdentityUser = registeringUser, Email = email, UserName = userName, ZipCode = zipCode});
        await _dbContext.SaveChangesAsync();
        
        return new AuthResult(true, email, userName, "");
    }


    public async Task<AuthResult> LoginAsync(string email, string password)
    {
        var managedUser = await _userManager.FindByEmailAsync(email);
        if (managedUser == null)
        {
            return InvalidEmail(email);
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, password);
        if (!isPasswordValid)
        {
            return InvalidPassword(email, managedUser.UserName);
        }
        
        var roles = await _userManager.GetRolesAsync(managedUser);

        var accessToken = _tokenService.CreateToken(managedUser, roles[0]);
        return new AuthResult(true, managedUser.Email, managedUser.UserName, accessToken);
    }

    private static AuthResult FailedRegistration(IdentityResult result, string email, string userName)
    {
        var authResult = new AuthResult(false, email, userName, "");
        foreach (var error in result.Errors)
        {
            authResult.ErrorMessages.Add(error.Code, error.Description);
        }

        return authResult;
    }

    private static AuthResult InvalidPassword(string email, string userName)
    {
        var result = new AuthResult(false, email, userName, "");
        result.ErrorMessages.Add("Bad credentials", "Invalid password");
        return result;
    }

    private static AuthResult InvalidEmail(string email)
    {
        var result = new AuthResult(false, email, "", "");
        result.ErrorMessages.Add("Bad credentials", "Invalid email");
        return result;
    }
}