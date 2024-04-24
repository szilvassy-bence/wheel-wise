using Microsoft.EntityFrameworkCore;
using wheel_wise.Data;
using wheel_wise.Model;

namespace wheel_wise.Service.Repository.ColorRepo;

public class ColorRepository : IColorRepository
{
    private WheelWiseContext _dbContext;

    public ColorRepository(WheelWiseContext context)
    {
        _dbContext = context;
    }

    public async Task<IEnumerable<Color>> GetAll()
    {
        return await _dbContext.Colors.ToListAsync();
    }
    
    public async Task<Color?> GeById(int id)
    {
        return await _dbContext.Colors.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Color?> GetByName(string colorName)
    {
        return await _dbContext.Colors.FirstOrDefaultAsync(x => x.Name == colorName);
    }

    public async Task Add(Color color)
    {
        _dbContext.Colors.Add(color);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Color color)
    {
        _dbContext.Colors.Update(color);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Color color)
    {
        _dbContext.Colors.Remove(color);
        await _dbContext.SaveChangesAsync();
    }
}