namespace wheel_wise.Model.Filters;

public class PriceRange
{
    public decimal MinPrice { get; set; } = 0;
    public decimal MaxPrice { get; set; } = Int32.MaxValue;
}