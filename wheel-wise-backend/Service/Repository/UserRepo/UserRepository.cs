using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using wheel_wise.Data;
using wheel_wise.Model;
using wheel_wise.Model.DTO;

namespace wheel_wise.Service.Repository.UserRepo;

public class UserRepository : IUserRepository
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly WheelWiseContext _dbContext;

    public UserRepository(UserManager<IdentityUser> userManager, WheelWiseContext dbContext)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    
    public async Task<User> GetByName(string name)
    {
        var iUser = await _userManager.FindByNameAsync(name);
        
        return await _dbContext.Users.FirstOrDefaultAsync(x => x.IdentityUser.Id == iUser.Id);
    }

    public async Task UpdateUser(string id, UserData userData)
    {
        var user = await _userManager.FindByIdAsync(id);
        Console.WriteLine(userData.UserName);
        
        // check if the email address is used
        var useremail = await _userManager.FindByEmailAsync(userData.Email);
        if (useremail == null)
        {
            var result = await _userManager.ChangeEmailAsync(user, userData.Email, userData.Token);
        }

        // need a DTO
    }
    
    
}