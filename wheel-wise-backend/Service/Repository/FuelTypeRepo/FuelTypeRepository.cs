using Microsoft.EntityFrameworkCore;
using wheel_wise.Data;
using wheel_wise.Model;

namespace wheel_wise.Service.Repository.FuelTypeRepo;

public class FuelTypeRepository : IFuelTypeRepository
{
    private WheelWiseContext _dbContext;

    public FuelTypeRepository(WheelWiseContext context)
    {
        _dbContext = context;
    }

    public async Task<IEnumerable<FuelType>> GetAll()
    {
        return await _dbContext.FuelTypes.ToListAsync();
    }

    public async Task<FuelType?> GetByName(string fuelTypeName)
    {
        return await _dbContext.FuelTypes.FirstOrDefaultAsync(x => x.Name == fuelTypeName);
    }
    
    public async Task<FuelType?> GetById(int fuelTypeId)
    {
        return await _dbContext.FuelTypes.FindAsync(fuelTypeId);
    }

    public async Task Add(FuelType fuelType)
    {
        _dbContext.FuelTypes.Add(fuelType);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(FuelType fuelType)
    {
        _dbContext.FuelTypes.Update(fuelType);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(FuelType fuelType)
    {
        _dbContext.FuelTypes.Remove(fuelType);
        await _dbContext.SaveChangesAsync();
    }
}