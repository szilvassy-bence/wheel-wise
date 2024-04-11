using wheel_wise.Model;

namespace wheel_wise.Service.Filters;

public class TypeSpecification : ISpecification<Advertisement>
{
    private readonly string _type;

    public TypeSpecification(string type)
    {
        _type = type;
    }

    public bool IsSatisfied(Advertisement ad)
    {
        return ad.Car.CarType.Model == _type;
    }
}