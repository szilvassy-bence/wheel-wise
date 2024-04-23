using wheel_wise.Model;

namespace wheel_wise.Service.Filters;

public class BrandSpecification : ISpecification<Advertisement>
{
    private readonly string _brand;


    public BrandSpecification(string brand)
    {
        _brand = brand;
    }

    public bool IsSatisfied(Advertisement ad)
    {
        return ad.Car.CarType.Brand == _brand;
    }
}