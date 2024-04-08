using wheel_wise.Model;

namespace wheel_wise.Service;

public class ColorSpecification : ISpecification<Car>
{
    private readonly string _color;

    public ColorSpecification(string color)
    {
        _color = color;
    }


    /*public bool IsSatisfied(Car product)
    {
        return product.Color == _color;
    }*/
}