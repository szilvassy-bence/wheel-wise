using wheel_wise.Model;

namespace wheel_wise.Service.Repository.TransmissionRepo;

public interface ITransmissionRepository
{
    Task<IEnumerable<Transmission>> GetAll();
    Task<Transmission?> GetByName(string name);

    void Add(Transmission transmission);
    void Delete(Transmission transmission);
    void Update(Transmission transmission);
}