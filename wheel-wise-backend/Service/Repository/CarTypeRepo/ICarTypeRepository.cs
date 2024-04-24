using wheel_wise.Model;

namespace wheel_wise.Service.Repository.CarTypeRepo;

public interface ICarTypeRepository
{
    Task<IEnumerable<CarType>> GetAll();
    Task<CarType?> GetByCarModel(string brand, string model);

    Task<CarType>? GeById(int id);
    Task Add(CarType carCarType);
    Task Delete(CarType carCarType);
    Task Update(CarType carCarType);
}