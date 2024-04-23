using wheel_wise.Model;

namespace wheel_wise.Service.Filters;

public class AndSpecification : ISpecification<Advertisement>
{
    private readonly IEnumerable<ISpecification<Advertisement>> specs;

    public AndSpecification(IEnumerable<ISpecification<Advertisement>> specs)
    {
        this.specs = specs;
    }


    public bool IsSatisfied(Advertisement product)
    {
        bool flag = true;
        var carName = product.Car.CarType.Brand;
        foreach (var spec in specs)
        {
            if (!spec.IsSatisfied(product))
            {
                flag = false;
                break;
            }
        }

        return flag;
    }
}