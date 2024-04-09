using wheel_wise.Model;

namespace wheel_wise.Service.Repository.TransmissionRepo;

public interface ITransmissionRepository
{
    Task<IEnumerable<Transmission>> GetAll();
    Task<Transmission?> GetByName(string name);

    Task<Transmission?> GetById(int id); 
    Task Add(Transmission transmission);
    Task Delete(Transmission transmission);
    Task Update(Transmission transmission);
}