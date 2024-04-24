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
        
        return await _dbContext.Users.Include(x => x.FavoriteAdvertisements).ThenInclude(x => x.Advertisement).FirstOrDefaultAsync(x => x.IdentityUser.Id == iUser.Id);
    }

    public async Task AddFavoriteAdvertisement(string name, int adId)
    {
        var iUser = await _userManager.FindByNameAsync(name);
        
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.IdentityUser.Id == iUser.Id);
        
        var ad = await _dbContext.Advertisements.FirstOrDefaultAsync(x => x.Id == adId);

        var favAd = new FavouriteAd { AdvertisementId = ad.Id, UserId = user.Id };

        _dbContext.Add(favAd);
        
        
       await _dbContext.SaveChangesAsync();
    }
    
    
}