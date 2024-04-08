using Microsoft.EntityFrameworkCore;
using wheel_wise.Model;
using Type = wheel_wise.Model.Type;

namespace wheel_wise.Data;

public class WheelWiseContext : DbContext
{
    public DbSet<Advertisement> Advertisements { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<Type> Types { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=WheelWiseApi;User Id=sa;Password=yourStrong(!)Password;Encrypt=false;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var equipment1 = new Equipment { Id = 1, Type = "Technical", Name = "AC" };
        var equipment2 = new Equipment { Id = 2, Type = "Comfort", Name = "SeatHeating" };
        
        modelBuilder.Entity<Type>().HasData(new Type { Id = 1, Brand = "Opel", Model = "Astra" },
            new Type { Id = 2, Brand = "Renault", Model = "Clio" });
        modelBuilder.Entity<Equipment>().HasData(equipment1, equipment2);
        modelBuilder.Entity<Color>().HasData(new Color { Id = 1, Name = "White" }, new Color { Id = 2, Name = "Black" });
        modelBuilder.Entity<FuelType>().HasData(new FuelType { Id = 1, Name = "Diesel" }, new FuelType { Id = 2, Name = "Petrol" });
        modelBuilder.Entity<Transmission>().HasData(new Transmission { Id = 1, Name = "Manual" }, new FuelType { Id = 2, Name = "Automatic" });
        modelBuilder.Entity<Car>().HasData(new Car
        {
            Id = 1, ColorId = 1, Year = 2010, Price = 20000m, Mileage = 15000, Power = 100,
            FuelTypeId = 1, Status = Status.Used, TransmissionId = 1, TypeId = 1
        },  new Car { Id = 2, ColorId = 2, Year = 2010, Price = 20000m, Mileage = 15000, Power = 100,
        FuelTypeId = 2, Status = Status.Broken, TransmissionId = 2, TypeId = 2 });
        modelBuilder.Entity<Advertisement>().HasData(new Advertisement
        {
            Id = 1, CreatedAt = DateTime.Now, Highlighted = false, CarId = 1
        });
    }
}