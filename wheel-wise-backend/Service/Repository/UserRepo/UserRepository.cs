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
    
    public async Task<User?> GetByName(string userName)
    {
        var iUser = await _userManager.FindByNameAsync(userName);
        var user = await _dbContext.Users
            .Include(x => x.Advertisements)
            .Include(x => x.FavoriteAdvertisements)
            .FirstOrDefaultAsync(x => x.IdentityUser.Id == iUser.Id);
        return user;
    }

    public async Task<IEnumerable<Advertisement?>> GetFavoriteAdsByUserName(string userName)
    {

        var user = await GetByName(userName);

        if (user.FavoriteAdvertisements == null)
        {
            return new List<Advertisement>();
        }

        return user.FavoriteAdvertisements;
    }

    public async Task UpdateUser(string id, UserData userData)
    {
        var user = await _userManager.FindByIdAsync(id);
        
        if (user == null)
        {
            return;
        }

        if (user.Email != userData.Email)
        {
            var result = await _userManager.ChangeEmailAsync(user, userData.Email, userData.Token);
            //user.Email = userData.Email;
            
            //await _dbContext.SaveChangesAsync();
        }

        // need a DTO
    }
    
    

    public async Task AddFavoriteAdvertisement(string userName, int adId)
    {

        var user = await GetByName(userName);
        
        // if ad is already in user.FavoriteAdvertisements
        var currentAd = user.FavoriteAdvertisements.FirstOrDefault(x => x.Id == adId);
        if (currentAd != null)
        {
            return;
        }

        var ad = await _dbContext.Advertisements.FirstOrDefaultAsync(x => x.Id == adId);
        
        // if there is no ad with that ad id
        if (ad == null)
        {
            return;
        }

        // if the favorite advertisements is not yet initialized
        if (user.FavoriteAdvertisements == null)
        {
            user.FavoriteAdvertisements = new List<Advertisement>();
        }

        user.FavoriteAdvertisements.Add(ad);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveFavoriteAdvertisement(string userName, int adId)
    {
        var user = await GetByName(userName);
        
        var currentAd = user.FavoriteAdvertisements.FirstOrDefault(x => x.Id == adId);
        if (currentAd == null)
        {
            return;
        }
        user.FavoriteAdvertisements.Remove(currentAd);
        await _dbContext.SaveChangesAsync();
    }
}