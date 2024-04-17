using Microsoft.AspNetCore.Identity;

namespace wheel_wise.Service.Authentication;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenService _tokenService;

    public AuthService(UserManager<IdentityUser> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }


    public async Task<AuthResult> RegisterAsync(string email, string userName, string password, string role)
    {
        var user = new IdentityUser { Email = email, UserName = userName };
        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            return FailedRegistration(result, email, userName);
        }

        await _userManager.AddToRoleAsync(user, role);
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

        var accessToken = _tokenService.CreateToken(managedUser);
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