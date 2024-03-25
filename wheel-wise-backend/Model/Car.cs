namespace wheel_wise.Model;

public class Car
{
    public Car(int id, string name, string brand, string color)
    {
        Id = id;
        Name = name;
        Brand = brand;
        Color = color;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
}