using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace wheel_wise.Model;

public class Car
{
    // Required properties
    public int Id { get; init; }
    public int ColorId { get; set; }
    public Color Color { get; set; }
    public int Year { get; set; }
    
    //[Column(TypeName = "decimal(5, 2)")]
    [Precision(20,10)]
    public decimal Price { get; set; }
    public int Mileage { get; set; }
    public int Power { get; set; }
    public int FuelTypeId { get; set; }
    public FuelType FuelType { get; set; }
    public Status Status { get; set; }
    public int TransmissionId { get; set; }
    public Transmission Transmission { get; set; } 
    public int CarTypeId { get; set; }
    public CarType CarType { get; set; }
    public ICollection<Equipment> Equipments { get; set; }
}