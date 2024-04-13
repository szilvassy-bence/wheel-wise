namespace wheel_wise.Model.Filters;

public class FilterModel
{
    public string? Brand { get; set; }
    public string? Type { get; set; }
    public string? Color { get; set; }

    public PriceRange? PriceRange { get; set; }

    public override string ToString()
    {
        return $"{nameof(Brand)}: {Brand}, {nameof(Type)}: {Type}, {nameof(Color)}: {Color}, {nameof(PriceRange)}: {PriceRange}";
    }
}