using Microsoft.AspNetCore.Identity;
using wheel_wise.Model;

namespace wheel_wise.Service.Repository.UserRepo;

public interface IUserRepository
{
    Task<User> GetByName(string name);
    Task AddFavoriteAdvertisement(string name, int adId);
}