using wheel_wise.Model;

namespace wheel_wise.Service.Repository.AdvertisementRepo;

public interface IAdvertisementRepository
{
    Task<IEnumerable<Advertisement>> GetAll();
    Task<Advertisement?> GetById(int id);
    Task Add(Advertisement advertisement);
    Task Delete(Advertisement advertisement);
    Task Update(Advertisement advertisement);
}