using Microsoft.EntityFrameworkCore;
using wheel_wise.Data;
using wheel_wise.Model;

namespace wheel_wise.Service.Repository.CarTypeRepo;

public class CarTypeRepository : ICarTypeRepository
{
    private WheelWiseContext _dbContext;

    public CarTypeRepository(WheelWiseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<CarType>> GetAll()
    {
        return await _dbContext.CarTypes.ToListAsync();
    }
    
    public async Task<CarType?> GetByCarModel(string brand,string model)
    {
        return (await _dbContext.CarTypes.FirstOrDefaultAsync(c => (c.Model == model && c.Brand == brand)))!;
    }

    public async Task Add(CarType carCarTypes)
    {
        _dbContext.Add(carCarTypes);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<CarType?> GeById(int id)
    {
        return await _dbContext.CarTypes.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task Delete(CarType carCarTypes)
    {
        _dbContext.Remove(carCarTypes);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task Update(CarType carCarTypes)
    {
        _dbContext.Update(carCarTypes);
        await _dbContext.SaveChangesAsync();
    }
}