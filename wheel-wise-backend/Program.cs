using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
builder.Services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
builder.Services.AddScoped<ICarTypeRepository, CarTypeRepository>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IFuelTypeRepository, FuelTypeRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ITransmissionRepository, TransmissionRepository>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
AddDbContext();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("CorsPolicy");
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void AddDbContext()
{
    var conStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("WheelWiseContext"));
    conStrBuilder.Password = builder.Configuration["DbPassword"];
    var connection = conStrBuilder.ConnectionString;
    builder.Services.AddDbContext<WheelWiseContext>(options =>
        options.UseSqlServer(connection));
}