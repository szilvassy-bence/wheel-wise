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
        return await _dbContext.Types.ToListAsync();
    }
    
    public async Task<CarType>? GetByCarModel(string brand,string model)
    {
        return (await _dbContext.Types.FirstOrDefaultAsync(c => (c.Model == model && c.Brand == brand)))!;
    }

    public async void Add(CarType carCarTypes)
    {
        await _dbContext.AddAsync(carCarTypes);
        await _dbContext.SaveChangesAsync();
    }
    
    public async void Delete(CarType carCarTypes)
    {
        _dbContext.Remove(carCarTypes);
        await _dbContext.SaveChangesAsync();
    }
    
    public async void Update(CarType carCarTypes)
    {
        _dbContext.Update(carCarTypes);
        await _dbContext.SaveChangesAsync();
    }
}