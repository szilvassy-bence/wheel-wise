namespace wheel_wise.Contracts;

public class AdvertisementPostRequest
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public string FuelType { get; set; }
    public string Transmission { get; set; }
    public string Status { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public int Mileage { get; set; }
    public int Power { get; set; }
    public string UserName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Dictionary<int, bool> Equipments { get; set; }
}