using Microsoft.AspNetCore.Identity;

namespace wheel_wise.Service.Authentication;

public interface ITokenService
{
    string CreateToken(IdentityUser user, string? role);
}