using wheel_wise.Model;

namespace wheel_wise.Service.Repository.FuelTypeRepo;

public interface IFuelTypeRepository
{
    Task<IEnumerable<FuelType>> GetAll();
    Task<FuelType?> GetByName(string fuelTypeName);
    Task<FuelType?> GetById(int fuelTypeId);
    Task Add(FuelType fuelType);
    Task Update(FuelType fuelType);
    Task Delete(FuelType fuelType);
}