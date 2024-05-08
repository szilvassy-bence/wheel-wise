using Microsoft.AspNetCore.Identity;
using wheel_wise.Model;
using wheel_wise.Model.DTO;

namespace wheel_wise.Service.Repository.UserRepo;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetByName(string name);
    Task<IEnumerable<Advertisement?>> GetFavoriteAdsByUserName(string userName);
    Task<IEnumerable<Advertisement?>> GetAdsByUserName(string userName);
    Task AddFavoriteAdvertisement(string name, int adId);
    Task UpdateUser(string id, UserData userData);
    Task RemoveFavoriteAdvertisement(string userName, int adId);}