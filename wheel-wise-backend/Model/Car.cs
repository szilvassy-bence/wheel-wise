namespace wheel_wise.Model;

public class Car
{
    // Required properties
    public int Id { get; set; }
    public string Brand { get; set; }
    public string CarType { get; set; }
    public string Color { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public int Mileage { get; set; }
    public int Power { get; set; }
    public User Owner { get; set; }
}