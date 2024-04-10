using Microsoft.EntityFrameworkCore;
using wheel_wise.Model;

namespace wheel_wise.Data;

public class WheelWiseContext : DbContext
{
    public DbSet<Advertisement> Advertisements { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<CarType> CarTypes { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<FuelType> FuelTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=WheelWiseApi;User Id=sa;Password=yourStrong(!)Password;Encrypt=false;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var equipment1 = new Equipment { Id = 1, Type = "Technical", Name = "AC" };
        var equipment2 = new Equipment { Id = 2, Type = "Comfort", Name = "SeatHeating" };

        modelBuilder.Entity<CarType>().HasData(
            new CarType { Id = 1, Brand = "Opel", Model = "Astra" },
            new CarType { Id = 2, Brand = "Renault", Model = "Clio" },
            new CarType { Id = 3, Brand = "Ford", Model = "Fiesta" },
            new CarType { Id = 4, Brand = "Toyota", Model = "Corolla" },
            new CarType { Id = 5, Brand = "Volkswagen", Model = "Golf" },
            new CarType { Id = 6, Brand = "BMW", Model = "3 Series" },
            new CarType { Id = 7, Brand = "Mercedes-Benz", Model = "C-Class" },
            new CarType { Id = 8, Brand = "Audi", Model = "A3" },
            new CarType { Id = 9, Brand = "Honda", Model = "Civic" },
            new CarType { Id = 10, Brand = "Hyundai", Model = "i30" },
            new CarType { Id = 11, Brand = "Kia", Model = "Rio" },
            new CarType { Id = 12, Brand = "Mazda", Model = "3" },
            new CarType { Id = 13, Brand = "Nissan", Model = "Micra" },
            new CarType { Id = 14, Brand = "Peugeot", Model = "208" },
            new CarType { Id = 15, Brand = "Subaru", Model = "Impreza" },
            new CarType { Id = 16, Brand = "Suzuki", Model = "Swift" },
            new CarType { Id = 17, Brand = "Tesla", Model = "Model 3" },
            new CarType { Id = 18, Brand = "Volvo", Model = "V40" },
            new CarType { Id = 19, Brand = "Fiat", Model = "500" },
            new CarType { Id = 20, Brand = "Skoda", Model = "Octavia" });
        modelBuilder.Entity<Equipment>().HasData(equipment1, equipment2);
        modelBuilder.Entity<Color>()
            .HasData(new Color { Id = 1, Name = "White" }, new Color { Id = 2, Name = "Black" });
        modelBuilder.Entity<FuelType>().HasData(new FuelType { Id = 1, Name = "Diesel" },
            new FuelType { Id = 2, Name = "Petrol" });
        modelBuilder.Entity<Transmission>().HasData(new Transmission { Id = 1, Name = "Manual" },
            new FuelType { Id = 2, Name = "Automatic" });
        modelBuilder.Entity<Car>().HasData(new Car
        {
            Id = 1, ColorId = 1, Year = 2010, Price = 20000m, Mileage = 15000, Power = 100,
            FuelTypeId = 1, Status = Status.Used, TransmissionId = 1, CarTypeId = 1
        }, new Car
        {
            Id = 2, ColorId = 2, Year = 2010, Price = 20000m, Mileage = 15000, Power = 100,
            FuelTypeId = 2, Status = Status.Broken, TransmissionId = 2, CarTypeId = 2
        },
            new Car
        {
            Id = 3, ColorId = 1, Year = 2012, Price = 25000m, Mileage = 18000, Power = 120,
            FuelTypeId = 1, Status = Status.Used, TransmissionId = 1, CarTypeId = 3
        },
        new Car
        {
            Id = 4, ColorId = 2, Year = 2015, Price = 30000m, Mileage = 20000, Power = 140,
            FuelTypeId = 2, Status = Status.Broken, TransmissionId = 2, CarTypeId = 4
        },
        new Car
        {
            Id = 5, ColorId = 1, Year = 2018, Price = 35000m, Mileage = 15000, Power = 160,
            FuelTypeId = 1, Status = Status.Used, TransmissionId = 1, CarTypeId = 5
        },
        new Car
        {
            Id = 6, ColorId = 2, Year = 2020, Price = 40000m, Mileage = 10000, Power = 180,
            FuelTypeId = 2, Status = Status.New, TransmissionId = 2, CarTypeId = 6
        },
        new Car
        {
            Id = 7, ColorId = 1, Year = 2016, Price = 32000m, Mileage = 22000, Power = 150,
            FuelTypeId = 1, Status = Status.Used, TransmissionId = 1, CarTypeId = 7
        },
        new Car
        {
            Id = 8, ColorId = 2, Year = 2014, Price = 28000m, Mileage = 19000, Power = 130,
            FuelTypeId = 2, Status = Status.Used, TransmissionId = 2, CarTypeId = 8
        },
        new Car
        {
            Id = 9, ColorId = 1, Year = 2017, Price = 33000m, Mileage = 17000, Power = 170,
            FuelTypeId = 1, Status = Status.Used, TransmissionId = 1, CarTypeId = 9
        },
        new Car
        {
            Id = 10, ColorId = 2, Year = 2019, Price = 37000m, Mileage = 14000, Power = 190,
            FuelTypeId = 2, Status = Status.New, TransmissionId = 2, CarTypeId = 10
        },
        new Car
        {
            Id = 11, ColorId = 1, Year = 2013, Price = 26000m, Mileage = 21000, Power = 140,
            FuelTypeId = 1, Status = Status.New, TransmissionId = 1, CarTypeId = 11
        },
        new Car
        {
            Id = 12, ColorId = 2, Year = 2016, Price = 32000m, Mileage = 18000, Power = 160,
            FuelTypeId = 2, Status = Status.New, TransmissionId = 2, CarTypeId = 12
        },
        new Car
        {
            Id = 13, ColorId = 1, Year = 2017, Price = 33000m, Mileage = 20000, Power = 170,
            FuelTypeId = 1, Status = Status.New, TransmissionId = 1, CarTypeId = 13
        },
        new Car
        {
            Id = 14, ColorId = 2, Year = 2015, Price = 30000m, Mileage = 18000, Power = 150,
            FuelTypeId = 2, Status = Status.New, TransmissionId = 2, CarTypeId = 14
        },
        new Car
        {
            Id = 15, ColorId = 1, Year = 2018, Price = 35000m, Mileage = 15000, Power = 170,
            FuelTypeId = 1, Status = Status.New, TransmissionId = 1, CarTypeId = 15
        },
        new Car
        {
            Id = 16, ColorId = 2, Year = 2019, Price = 37000m, Mileage = 12000, Power = 190,
            FuelTypeId = 2, Status = Status.New, TransmissionId = 2, CarTypeId = 16
        },
        new Car
        {
            Id = 17, ColorId = 1, Year = 2014, Price = 28000m, Mileage = 19000, Power = 140,
            FuelTypeId = 1, Status = Status.New, TransmissionId = 1, CarTypeId = 17
        },
        new Car
        {
            Id = 18, ColorId = 2, Year = 2016, Price = 32000m, Mileage = 18000, Power = 160,
            FuelTypeId = 2, Status = Status.New, TransmissionId = 2, CarTypeId = 18
        },
        new Car
        {
            Id = 19, ColorId = 1, Year = 2017, Price = 33000m, Mileage = 20000, Power = 170,
            FuelTypeId = 1, Status = Status.New, TransmissionId = 1, CarTypeId = 19
        });
        modelBuilder.Entity<Advertisement>().HasData(
            new Advertisement
        {
            Id = 1, CreatedAt = DateTime.Now, Highlighted = false, CarId = 1
        },
        new Advertisement
        {
            Id = 2, CreatedAt = DateTime.Now, Highlighted = false, CarId = 2
        },
        new Advertisement
        {
            Id = 3, CreatedAt = DateTime.Now, Highlighted = false, CarId = 3
        },
        new Advertisement
        {
            Id = 4, CreatedAt = DateTime.Now, Highlighted = false, CarId = 4
        },
        new Advertisement
        {
            Id = 5, CreatedAt = DateTime.Now, Highlighted = false, CarId = 5
        },
        new Advertisement
        {
            Id = 6, CreatedAt = DateTime.Now, Highlighted = false, CarId = 6
        },
        new Advertisement
        {
            Id = 7, CreatedAt = DateTime.Now, Highlighted = false, CarId = 7
        },
        new Advertisement
        {
            Id = 8, CreatedAt = DateTime.Now, Highlighted = false, CarId = 8
        },
        new Advertisement
        {
            Id = 9, CreatedAt = DateTime.Now, Highlighted = false, CarId = 9
        },
        new Advertisement
        {
            Id = 10, CreatedAt = DateTime.Now, Highlighted = false, CarId = 10
        },
        new Advertisement
        {
            Id = 11, CreatedAt = DateTime.Now, Highlighted = false, CarId = 11
        },
        new Advertisement
        {
            Id = 12, CreatedAt = DateTime.Now, Highlighted = false, CarId = 12
        },
        new Advertisement
        {
            Id = 13, CreatedAt = DateTime.Now, Highlighted = false, CarId = 13
        },
        new Advertisement
        {
            Id = 14, CreatedAt = DateTime.Now, Highlighted = false, CarId = 14
        },
        new Advertisement
        {
            Id = 15, CreatedAt = DateTime.Now, Highlighted = false, CarId = 15
        },
        new Advertisement
        {
            Id = 16, CreatedAt = DateTime.Now, Highlighted = false, CarId = 16
        },
        new Advertisement
        {
            Id = 17, CreatedAt = DateTime.Now, Highlighted = false, CarId = 17
        },
        new Advertisement
        {
            Id = 18, CreatedAt = DateTime.Now, Highlighted = false, CarId = 18
        },
        new Advertisement
        {
            Id = 19, CreatedAt = DateTime.Now, Highlighted = false, CarId = 19
        });

        // Unidirectional many-to-many
        modelBuilder.Entity<Car>()
            .HasMany(e => e.Equipments)
            .WithMany();
    }
}