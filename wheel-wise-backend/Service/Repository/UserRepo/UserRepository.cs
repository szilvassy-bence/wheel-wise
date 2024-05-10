using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wheel_wise.Contracts;
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

    public async Task<IEnumerable<User>> GetAll()
    {
        try
        {
            var users = await _dbContext.Users.Include(u => u.IdentityUser).ToListAsync();
            return users;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<User?> GetByName(string userName)
    {
        var iUser = await _userManager.FindByNameAsync(userName);
        if (iUser is null)
        {
            throw (new NullReferenceException($"User with user name {userName} is not found."));
        }

        var user = await _dbContext.Users
            .Include(x => x.Advertisements)
            .Include(x => x.FavoriteAdvertisements)
            .FirstOrDefaultAsync(x => x.IdentityUser.Id == iUser.Id);

        //var emptiedUser = new User { IdentityUser = null, UserName = user.UserName };
            
        return user;
    }

    public async Task<IEnumerable<Advertisement?>> GetFavoriteAdsByUserName(string userName)
    {
        var iUser = await _userManager.FindByNameAsync(userName);
        var user = await _dbContext.Users
            .Include(u => u.FavoriteAdvertisements).ThenInclude(a => a.Car)
            .ThenInclude(x => x.CarType)
            .FirstOrDefaultAsync(x => x.IdentityUser.Id == iUser.Id);

        if (user.FavoriteAdvertisements == null)
        {
            return new List<Advertisement>();
        }

        return user.FavoriteAdvertisements;
    }

    public async Task<IEnumerable<AdvertisementDTO?>> GetAdsByUserName(string userName)
    {
        /*var iUser = await _userManager.FindByNameAsync(userName);
        if (iUser is null)
        {
            throw (new NullReferenceException($"User with user name {userName} is not found."));
        }
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.IdentityUser.Id == iUser.Id);
        
        if (user is null)
        {
            throw (new NullReferenceException($"User with user name {userName} is not found."));
        }*/

        /*public int Id { get; init; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Highlighted { get; set; }
    
        public int? UserId { get; init; }
        public string UserName { get; init; }
    
        public int CarId { get; init; }
        public Car Car { get; set; */

        var emptyUser = await _dbContext.Users.Where(x => userName == x.IdentityUser.UserName)
            .SelectMany(x => x.Advertisements).Include(c=>c.Car)
            .Include(x => x.Car.CarType)
            .Include(x => x.Car.Transmission)
            .Include(x => x.Car.FuelType)
            .Include(x => x.Car.Equipments)
            .Include(x => x.Car.Color)
            .Select(x => new AdvertisementDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                Highlighted = x.Highlighted,
                UserId = x.UserId,
                UserName = x.User.UserName,
                CarId = x.CarId,
                Car = x.Car
            }).ToListAsync();
        
        
        //var adList = user.Advertisements.ToList();

        //adList.ForEach(x => x.User.IdentityUser = null);

        return emptyUser;
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

        // if the favorite advertisements is not yet initialized
        if (user.FavoriteAdvertisements == null)
        {
            user.FavoriteAdvertisements = new List<Advertisement>();
        }

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
            throw new InvalidOperationException("The ad you are trying to add to another entity does not exist.");
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
            throw (new InvalidOperationException("The ad you are trying to add to another entity does not exist."));
        }

        user.FavoriteAdvertisements.Remove(currentAd);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<RegistrationResponse> UpdateIdentityUserData(IdentityUser identityUser, DataChangeRequest dataChangeRequest)
    { 
        var userByEmail = await _userManager.FindByEmailAsync(dataChangeRequest.Email);
        if (userByEmail != null && identityUser != userByEmail)
        {
            throw (new InvalidOperationException($"User email: {dataChangeRequest.Email} is already taken!"));
        }

        var userByUserName = await _userManager.FindByNameAsync(dataChangeRequest.UserName);
        if (userByUserName != null && identityUser != userByUserName)
        {
            throw (new Exception($"User name: {dataChangeRequest.UserName} is already taken!"));
        }

        if (!string.IsNullOrEmpty(dataChangeRequest.Email))
        {
            identityUser.Email = dataChangeRequest.Email;
            identityUser.NormalizedEmail = dataChangeRequest.Email.ToUpper();
        }
        else
        {
            throw (new InvalidOperationException("Email cannot be empty."));
        }
        
        if (!string.IsNullOrEmpty(dataChangeRequest.UserName))
        {
            identityUser.UserName = dataChangeRequest.UserName;
            identityUser.NormalizedUserName = dataChangeRequest.UserName.ToUpper();
        }
        else
        {
            throw (new InvalidOperationException("User name cannot be empty."));
        }

        await _dbContext.SaveChangesAsync();
        return new RegistrationResponse(dataChangeRequest.Email, dataChangeRequest.UserName);
    }

    public async Task DeleteUser(User user)
    {
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<RegistrationResponse> UpdatePasswordById(IdentityUser identityUser, PasswordChangeRequest passwordChangeRequest)
    {
        var result = await _userManager.ChangePasswordAsync(identityUser, passwordChangeRequest.ExistingPassword,
            passwordChangeRequest.newPassword);
        if (!result.Succeeded)
        {
            var sb = new StringBuilder();
            foreach (var error in result.Errors)
            {
                sb.AppendLine($"Error code: {error.Code}, error description: {error.Description}");
                throw (new InvalidOperationException(sb.ToString()));
            }
        }

        return new RegistrationResponse(identityUser.Email, identityUser.UserName);
    }

    public async Task<IdentityUser> GetIdentityUserById(string id)
    {
        return await _userManager.FindByIdAsync(id);
    }
    
    public async Task<User> GetUserById(int id)
    {
        return await _dbContext.Users.FindAsync(id);
    }
}