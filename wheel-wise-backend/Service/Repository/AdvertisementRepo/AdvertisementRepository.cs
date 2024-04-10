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
        return await _dbContext.Advertisements
            .Include(c => c.Car)
            .Include(x => x.Car.CarType)
            .Include(x => x.Car.Transmission)
            .Include(x => x.Car.FuelType)
            .Include(x => x.Car.Equipments)
            .Include(x => x.Car.Color)
            .ToListAsync();
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
    
    // ask mentors about update
    // https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/update-related-data?view=aspnetcore-8.0
    // https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core/8-exercise-implement-crud
    public async Task Update(Advertisement advertisement)
    {
        _dbContext.Advertisements.Update(advertisement);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task UpdateById(int id, Advertisement advertisement)
    {
        var ad = await _dbContext.Advertisements.FindAsync(id);
        if (ad != null)
        {
            ad.Highlighted = advertisement.Highlighted;
            await _dbContext.SaveChangesAsync();
        }
    }
}