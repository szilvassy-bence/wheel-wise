using Microsoft.EntityFrameworkCore;
using wheel_wise.Data;
using wheel_wise.Model;

namespace wheel_wise.Service.Repository.EquipmentRepo;

public class EquipmentRepository : IEquipmentRepository
{
    private readonly WheelWiseContext _dbContext;

    public EquipmentRepository(WheelWiseContext context)
    {
        _dbContext = context;
    }

    public async Task<IEnumerable<Equipment>> GetAll()
    {
        return await _dbContext.Equipments.ToListAsync();
    }

    public async Task<Equipment> GetByName(string equipmentName)
    {
        return await _dbContext.Equipments.FirstOrDefaultAsync(x => x.Name == equipmentName);
    }
    
    public async Task<Equipment?> GetById(int equipmentId)
    {
        return await _dbContext.Equipments.FindAsync(equipmentId);
    }

    public async Task Add(Equipment equipment)
    {
        _dbContext.Equipments.Add(equipment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Equipment equipment)
    {
        _dbContext.Equipments.Update(equipment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Equipment equipment)
    {
        _dbContext.Equipments.Remove(equipment);
        await _dbContext.SaveChangesAsync();
    }
}