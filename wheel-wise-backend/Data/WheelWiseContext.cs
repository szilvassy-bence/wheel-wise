using Microsoft.EntityFrameworkCore;
using wheel_wise.Model;
using Color = System.Drawing.Color;
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
        modelBuilder.Entity<Type>().HasData(new Type { Id = 1, Brand = "Opel", Model = "Astra" },
            new Type { Id = 2, Brand = "Renault", Model = "Clio" });
        modelBuilder.Entity<Equipment>().HasData(new Equipment { Id = 1, Type = "Technical", Name = "AC" },
            new Equipment { Id = 2, Type = "Comfort", Name = "SeatHeating" });
        modelBuilder.Entity<Car>().HasData(new Car
        {
            Id = 1, Color = wheel_wise.Model.Color.Green, Year = 2010, Price = 20000m, Mileage = 15000, Power = 100,
            FuelType = FuelType.Diesel, Status = Status.Used, Transmission = Transmission.Manual, TypeId = 1
        });
        /*modelBuilder.Entity<Advertisement>().HasData(new Advertisement
        {
            CreatedAt = DateTime.Now, Highlighted = false, CarId = 1
        });*/
    }
}