using Microsoft.EntityFrameworkCore;
using wheel_wise.Data;
using wheel_wise.Model;
using Type = wheel_wise.Model.Type;

namespace wheel_wise.Service.Repository.TypeRepo;

public class TypeRepository : ITypeRepository
{
    private WheelWiseContext _dbContext;

    public TypeRepository(WheelWiseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Type>> GetAll()
    {
        return await _dbContext.Types.ToListAsync();
    }
    
    public async Task<Type>? GetByCarModel(string brand,string model)
    {
        return (await _dbContext.Types.FirstOrDefaultAsync(c => (c.Model == model && c.Brand == brand)))!;
    }

    public async void Add(Type carTypes)
    {
        await _dbContext.AddAsync(carTypes);
        await _dbContext.SaveChangesAsync();
    }
    
    public async void Delete(Type carTypes)
    {
        _dbContext.Remove(carTypes);
        await _dbContext.SaveChangesAsync();
    }
    
    public async void Update(Type carTypes)
    {
        _dbContext.Update(carTypes);
        await _dbContext.SaveChangesAsync();
    }
}