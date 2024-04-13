namespace wheel_wise.Service.Filters;

public interface IFilter<T>
{
    IEnumerable<T> FilterProducts(IEnumerable<T> products, ISpecification<T> spec);
}