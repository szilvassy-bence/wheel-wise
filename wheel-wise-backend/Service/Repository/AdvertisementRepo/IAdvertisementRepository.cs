using wheel_wise.Model;

namespace wheel_wise.Service.Repository.AdvertisementRepo;

public interface IAdvertisementRepository
{
    Task<IEnumerable<Advertisement>> GetAll();
    void Add(Advertisement advertisement);
    void Delete(Advertisement advertisement);
    void Update(Advertisement advertisement);
}