using Microsoft.EntityFrameworkCore;
using wheel_wise.Data;
using wheel_wise.Model;

namespace wheel_wise.Service.Repository.TransmissionRepo;

public class TransmissionRepository : ITransmissionRepository
{
    private WheelWiseContext _dbContext;

    public TransmissionRepository(WheelWiseContext wheelWiseContext)
    {
        _dbContext = wheelWiseContext;
    }

    public async Task<IEnumerable<Transmission>> GetAll()
    {
        return await _dbContext.Transmissions.ToListAsync();
    }

    public async Task<Transmission?> GetById(int id)
    {
        return await _dbContext.Transmissions.FindAsync(id);
    }

    public async Task<Transmission?> GetByName(string name)
    {
        return await _dbContext.Transmissions.FirstOrDefaultAsync(t => t.Name == name);
    }

    public async Task Add(Transmission transmission)
    {
        _dbContext.Transmissions.Add(transmission);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Transmission transmission)
    {
        _dbContext.Transmissions.Remove(transmission);
        Console.WriteLine(_dbContext.Entry(transmission).State);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Transmission transmission)
    {
        _dbContext.Transmissions.Update(transmission);
        await _dbContext.SaveChangesAsync();
    }
}