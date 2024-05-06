using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using wheel_wise.Data;
using wheel_wise.Model;
using wheel_wise.Service.Authentication;
using wheel_wise.Service.Repository.AdvertisementRepo;
using wheel_wise.Service.Repository.CarRepo;
using wheel_wise.Service.Repository.CarTypeRepo;
using wheel_wise.Service.Repository.ColorRepo;
using wheel_wise.Service.Repository.EquipmentRepo;
using wheel_wise.Service.Repository.FuelTypeRepo;
using wheel_wise.Service.Repository.TransmissionRepo;
using wheel_wise.Service.Repository.UserRepo;

var builder = WebApplication.CreateBuilder(args);

LoadEnvironmentVariables();
AddServices();
ConfigureSwagger();
AddDbContext();
AddAuthentication();
AddIdentity();

var app = builder.Build();

using var scope = app.Services.CreateScope(); // AuthenticationSeeder is a scoped service, therefore we need a scope instance to access it
var authenticationSeeder = scope.ServiceProvider.GetRequiredService<AuthenticationSeeder>();
authenticationSeeder.AddRoles();
authenticationSeeder.AddAdmin();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("CorsPolicy");
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

void AddServices()
{
    //builder.Services.AddHttpContextAccessor(); 
    //builder.Services.AddScoped<UserManager<User>>(); 
    builder.Services.AddControllers()
        .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);;
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
    builder.Services.AddScoped<ICarTypeRepository, CarTypeRepository>();
    builder.Services.AddScoped<IColorRepository, ColorRepository>();
    builder.Services.AddScoped<IFuelTypeRepository, FuelTypeRepository>();
    builder.Services.AddScoped<ICarRepository, CarRepository>();
    builder.Services.AddScoped<ITransmissionRepository, TransmissionRepository>();
    builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddScoped<ITokenService, TokenService>();
    builder.Services.AddScoped<AuthenticationSeeder>();
}

void ConfigureSwagger()
{
    builder.Services.AddSwaggerGen(option =>
    {
        option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
    });
}

void AddDbContext()
{
    var conStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("WheelWiseContext"));
    conStrBuilder.Password = Environment.GetEnvironmentVariable("DB_PASSWORD");
    var connection = conStrBuilder.ConnectionString;
    
    builder.Services.AddDbContext<WheelWiseContext>(options =>
        options.UseSqlServer(connection));
}

void AddAuthentication()
{
    builder.Services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ClockSkew = TimeSpan.Zero,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["TokenValidationParameters:ValidIssuer"],
                ValidAudience = builder.Configuration["TokenValidationParameters:ValidAudience"],
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("ISSUER_SIGNING_KEY")))
            };
        });
}

void AddIdentity()
{
    builder.Services
        .AddIdentityCore<IdentityUser>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 4;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<WheelWiseContext>();
}

void LoadEnvironmentVariables()
{
    var root = Directory.GetCurrentDirectory();
    var dotenv = Path.Combine(root, ".env");
    DotEnv.Load(dotenv);
    var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
}

public partial class Program{}