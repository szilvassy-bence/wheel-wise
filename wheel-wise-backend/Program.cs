using System.Reflection;
using wheel_wise.Data;
using wheel_wise.Model;
using wheel_wise.Service.Repository.AdvertisementRepo;
using wheel_wise.Service.Repository.CarRepo;
using wheel_wise.Service.Repository.CarTypeRepo;
using wheel_wise.Service.Repository.ColorRepo;
using wheel_wise.Service.Repository.EquipmentRepo;
using wheel_wise.Service.Repository.FuelTypeRepo;
using wheel_wise.Service.Repository.TransmissionRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WheelWiseContext>();
builder.Services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
builder.Services.AddScoped<ICarTypeRepository, CarTypeRepository>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IFuelTypeRepository, FuelTypeRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ITransmissionRepository, TransmissionRepository>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("CorsPolicy");
}

FilterModel filterModel = new FilterModel { Color = "white", Type = "Valami", PriceRange = new PriceRange{Max = 100000}};
Console.WriteLine($"{filterModel.Brand} is brand");
PropertyInfo[] properties = typeof(FilterModel).GetProperties();
foreach (var property in properties)
{
    object? value = property.GetValue(filterModel);
    Console.WriteLine($"Property Name: {property.Name}, Value: {value}");
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();