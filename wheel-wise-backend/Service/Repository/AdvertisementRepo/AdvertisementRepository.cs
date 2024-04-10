using Microsoft.EntityFrameworkCore;
using wheel_wise.Data;
using wheel_wise.Model;

namespace wheel_wise.Service.Repository.AdvertisementRepo;

public class AdvertisementRepository : IAdvertisementRepository
{
    private WheelWiseContext _dbContext;

    public AdvertisementRepository(WheelWiseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Advertisement>> GetAll()
    {
        return await _dbContext.Advertisements.Include(c => c.Car).ToListAsync();
    }

    public async Task<Advertisement?> GetById(int id)
    {
        return await _dbContext.Advertisements.FindAsync(id);
    }

    public async Task Add(Advertisement advertisement)
    {
        _dbContext.Advertisements.Add(advertisement);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task Delete(Advertisement advertisement)
    {
        _dbContext.Advertisements.Remove(advertisement);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task Update( Advertisement advertisement)
    {
        _dbContext.Advertisements.Update(advertisement);
        await _dbContext.SaveChangesAsync();
    }
}