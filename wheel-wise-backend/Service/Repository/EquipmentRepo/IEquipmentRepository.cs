using wheel_wise.Model;

namespace wheel_wise.Service.Repository.EquipmentRepo;

public interface IEquipmentRepository
{
    Task<IEnumerable<Equipment>> GetAll();
    Task<Equipment> GetByName(string equipmentName);
    Task<Equipment?> GetById(int equipmentId);
    Task Add(Equipment equipment);
    Task Update(Equipment equipment);
    Task Delete(Equipment equipment);
}