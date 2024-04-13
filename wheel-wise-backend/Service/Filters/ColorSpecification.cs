using wheel_wise.Model;

namespace wheel_wise.Service.Filters;

public class ColorSpecification : ISpecification<Advertisement>
{
    private readonly string _color;

    public ColorSpecification(string color)
    {
        _color = color;
    }


    public bool IsSatisfied(Advertisement ad)
    {
        return ad.Car.Color.Name == _color;
    }
}