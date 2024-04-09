using System.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using wheel_wise.Data;
using wheel_wise.Model;
using wheel_wise.Service;
using wheel_wise.Model;

namespace wheel_wise.Service.Repository.CarRepo;

using Microsoft.AspNetCore.Mvc;


public class CarRepository: ICarRepository
{
    private WheelWiseContext _dbContext;

    public CarRepository(WheelWiseContext wheelWiseContext)
    {
        _dbContext = wheelWiseContext;
    }
    
    public async Task<IEnumerable<Car>> GetAll()
    {
        return await _dbContext.Cars.ToListAsync();
    }
    
    public async Task<Car?> GetById(int id)
    {
        return await _dbContext.Cars.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task Add(Car car)
    {
        _dbContext.Add(car);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Car car)
    { 
        _dbContext.Remove(car);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Car car)
    {
        _dbContext.Update(car);
        await _dbContext.SaveChangesAsync();
    }
}