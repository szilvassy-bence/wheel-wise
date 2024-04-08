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
        return await _dbContext.Advertisements.ToListAsync();
    }

    public async void Add(Advertisement advertisement)
    {
        await _dbContext.AddAsync(advertisement);
        await _dbContext.SaveChangesAsync();
    }
    
    public async void Delete(Advertisement advertisement)
    {
        _dbContext.Remove(advertisement);
        await _dbContext.SaveChangesAsync();
    }
    
    public async void Update(Advertisement advertisement)
    {
        _dbContext.Update(advertisement);
        await _dbContext.SaveChangesAsync();
    }
}