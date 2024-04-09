using wheel_wise.Model;

namespace wheel_wise.Service.Filters;

public class PriceSpecification : ISpecification<Car>
{
    private readonly PriceRange _priceRange;

    public PriceSpecification(PriceRange priceRange)
    {
        _priceRange = priceRange;
    }

    public bool IsSatisfied(Car product)
    {
        return product.Price >= _priceRange.Min && product.Price <= _priceRange.Max;
    }
}