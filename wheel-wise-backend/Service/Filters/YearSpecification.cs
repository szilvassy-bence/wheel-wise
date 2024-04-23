using wheel_wise.Model;
using wheel_wise.Model.Filters;

namespace wheel_wise.Service.Filters;

public class YearSpecification : ISpecification<Advertisement>
{
    private readonly YearRange _yearRange;

    public YearSpecification(YearRange yearRange)
    {
        _yearRange = yearRange;
    }

    public bool IsSatisfied(Advertisement ad)
    {
        return ad.Car.Year >= _yearRange.FromYear && ad.Car.Year <= _yearRange.TillYear;
    }
}