namespace wheel_wise.Model.Filters;

public class SimpleFilter
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int FromYear { get; set; }
    public int TillYear { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }

    public override string ToString()
    {
        return
            $"{nameof(Brand)}: {Brand}, {nameof(Model)}: {Model}, {nameof(FromYear)}: {FromYear}, {nameof(TillYear)}: {TillYear}, {nameof(MinPrice)}: {MinPrice}, {nameof(MaxPrice)}: {MaxPrice}";
    }
}