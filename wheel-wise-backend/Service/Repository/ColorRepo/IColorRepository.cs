

using wheel_wise.Model;

namespace wheel_wise.Service.Repository.ColorRepo;

public interface IColorRepository
{
    Task<IEnumerable<Color>> GetAll();
    Task<Color?> GetByName(string colorName);
    public Task<Color?> GeById(int id);
    Task Add(Color color);
    Task Update(Color color);
    Task Delete(Color color);
}