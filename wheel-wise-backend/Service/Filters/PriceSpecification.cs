using wheel_wise.Model;
using wheel_wise.Model.Filters;

namespace wheel_wise.Service.Filters;

public class PriceSpecification : ISpecification<Advertisement>
{
    private readonly PriceRange _priceRange;

    public PriceSpecification(PriceRange priceRange)
    {
        _priceRange = priceRange;
    }

    public bool IsSatisfied(Advertisement ad)
    {
        return ad.Car.Price >= _priceRange.MinPrice && ad.Car.Price <= _priceRange.MaxPrice;
    }
}