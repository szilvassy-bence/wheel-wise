using wheel_wise.Model;

namespace wheel_wise.Service;

public class TypeSpecification : ISpecification<Car>
{
    private readonly string _type;

    public TypeSpecification(string type)
    {
        _type = type;
    }

    /*public bool IsSatisfied(Car product)
    {
        return product.CarType == _type;
    }*/
}