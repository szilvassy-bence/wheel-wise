namespace wheel_wise.Model.Filters;

public class YearRange
{
    public int FromYear { get; set; } = 1900;
    public int TillYear { get; set; } = DateTime.Now.Year;
}