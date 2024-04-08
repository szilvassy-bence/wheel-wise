using Type = wheel_wise.Model.Type;

namespace wheel_wise.Service.Repository.TypeRepo;

public interface ITypeRepository
{
    Task<IEnumerable<Type>> GetAll();
    Task<Type>? GetByCarModel(string brand, string model);
    void Add(Type carType);
    void Delete(Type carType);
    void Update(Type carType);
}