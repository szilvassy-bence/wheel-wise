using Microsoft.EntityFrameworkCore;
using wheel_wise.Data;
using wheel_wise.Model;
using wheel_wise.Model.Filters;
using wheel_wise.Service.Filters;

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
            .Include(x => x.User)
            .ToListAsync();
    }

    public async Task<IEnumerable<Advertisement>> GetBySimpleFilter(SimpleFilter simpleFilter)
    {
        var allAds = await GetAll();
        ISpecification<Advertisement> andSpecification = GetSpecification(simpleFilter);

        IFilter<Advertisement> filter = new Filter();

        return filter.FilterProducts(allAds, andSpecification).ToList();
    }

    public async Task<IEnumerable<Advertisement>> GetHighlightedAds()
    {
        return await _dbContext.Advertisements
            .Where(a => a.Highlighted == true)
            .Include(c => c.Car)
            .Include(x => x.Car.CarType)
            .Include(x => x.Car.Transmission)
            .Include(x => x.Car.FuelType)
            .Include(x => x.Car.Equipments)
            .Include(x => x.Car.Color)
            .Take(8)
            .ToListAsync();
    }

    public async Task<Advertisement?> GetById(int id)
    {
        return await _dbContext.Advertisements
            .Include(c => c.Car)
            .Include(x => x.Car.CarType)
            .Include(x => x.Car.Transmission)
            .Include(x => x.Car.FuelType)
            .Include(x => x.Car.Equipments)
            .Include(x => x.Car.Color)
            .Include(u=> u.User)
            .FirstOrDefaultAsync(a => a.Id == id);
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
        _dbContext.Advertisements.Include(c => c.Car)
            .Include(x => x.Car.CarType)
            .Include(x => x.Car.Transmission)
            .Include(x => x.Car.FuelType)
            .Include(x => x.Car.Equipments)
            .Include(x => x.Car.Color);

        _dbContext.Advertisements.Update(advertisement);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Advertisement?> UpdateById(int id, Advertisement advertisement)
    {
        var ad = await _dbContext.Advertisements.Include(c=>c.Car)
            .FirstOrDefaultAsync(a => a.Id == id);
        if (ad != null)
        {
            ad.Highlighted = advertisement.Highlighted;
            //_dbContext.ChangeTracker.DetectChanges();
            Console.WriteLine(_dbContext.ChangeTracker.DebugView.LongView);
            await _dbContext.SaveChangesAsync();
        }

        return ad;
    }

    private ISpecification<Advertisement> GetSpecification(SimpleFilter simpleFilter)
    {
        IList<ISpecification<Advertisement>> specs = new List<ISpecification<Advertisement>>();

        if (simpleFilter.Brand != "Select Brand" && simpleFilter.Brand != "")
        {
            ISpecification<Advertisement> brandSpecification = new BrandSpecification(simpleFilter.Brand);
            specs.Add(brandSpecification);
        }

        if (simpleFilter.Model != "Select Model" && simpleFilter.Model != "")
        {
            ISpecification<Advertisement> modelSpecification = new ModelSpecification(simpleFilter.Model);
            specs.Add(modelSpecification);
        }

        if (simpleFilter.MaxPrice == 0 && simpleFilter.MinPrice != 0) // find ads above min price
        {
            PriceRange pr = new PriceRange { MinPrice = simpleFilter.MinPrice, MaxPrice = Int32.MaxValue };
            ISpecification<Advertisement> priceSpecification = new PriceSpecification(pr);
            specs.Add(priceSpecification);
        }
        else if (simpleFilter.MaxPrice != 0) // find ads if max price is not specified
        {
            PriceRange pr = new PriceRange { MinPrice = simpleFilter.MinPrice, MaxPrice = simpleFilter.MaxPrice };
            ISpecification<Advertisement> priceSpecification = new PriceSpecification(pr);
            specs.Add(priceSpecification);
        }

        if (simpleFilter.TillYear == 0 &&
            simpleFilter.FromYear != 0) // find ads if min year is specified, max year is set to zero
        {
            YearRange yr = new YearRange { FromYear = simpleFilter.FromYear };
            ISpecification<Advertisement> yearSpecification = new YearSpecification(yr);
            specs.Add(yearSpecification);
        }
        else if (simpleFilter.TillYear != 0) // find ads with restricted Till Year
        {
            YearRange yr = new YearRange { FromYear = simpleFilter.FromYear, TillYear = simpleFilter.TillYear };
            ISpecification<Advertisement> yearSpecification = new YearSpecification(yr);
            specs.Add(yearSpecification);
        }

        return new AndSpecification(specs);
    }
    
    public partial class Program{}
}