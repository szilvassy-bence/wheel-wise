using wheel_wise.Model;

namespace wheel_wise.Service.Repository.CarRepo;

public interface ICarRepository
{
    Task<IEnumerable<Car>> GetAll();
    Task<Car?> GetById(int id);

    Task Add(Car car);
    Task Delete(Car car);
    Task Update(Car car);
}