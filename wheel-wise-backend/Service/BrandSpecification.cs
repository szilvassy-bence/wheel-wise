using wheel_wise.Model;

namespace wheel_wise.Service;

public class BrandSpecification : ISpecification<Car>
{
    private readonly string _brand;


    public BrandSpecification(string brand)
    {
        _brand = brand;
    }

    /*public bool IsSatisfied(Car product)
    {
        return product.Brand == _brand;
    }*/
}