namespace wheel_wise.Service.Filters;

public interface ISpecification<T>
{
    bool IsSatisfied(T product);
}