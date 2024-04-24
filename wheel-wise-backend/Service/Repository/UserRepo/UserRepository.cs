using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using wheel_wise.Data;
using wheel_wise.Model;

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
    
    
}