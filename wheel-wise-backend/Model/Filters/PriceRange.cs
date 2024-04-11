namespace wheel_wise.Model;

public class PriceRange
{
    public decimal Min { get; set; } = 0;
    public decimal Max { get; set; } = Int32.MaxValue;
}