using wheel_wise.Model;
using wheel_wise.Model.Filters;

namespace wheel_wise.Service.Repository.AdvertisementRepo;

public interface IAdvertisementRepository
{
    Task<IEnumerable<Advertisement>> GetAll();
    Task<IEnumerable<Advertisement>> GetBySimpleFilter(SimpleFilter simpleFilter);
    Task<Advertisement?> GetById(int id);
    Task Add(Advertisement advertisement);
    Task Delete(Advertisement advertisement);
    Task Update(Advertisement advertisement);
    Task UpdateById(int id, Advertisement ad);
}