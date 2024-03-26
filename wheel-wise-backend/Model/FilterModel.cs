namespace wheel_wise.Model;

public class FilterModel
{
    public string? Brand { get; set; }
    public string? Type { get; set; }
    public string? Color { get; set; }

    public PriceRange? PriceRange { get; set; }
}