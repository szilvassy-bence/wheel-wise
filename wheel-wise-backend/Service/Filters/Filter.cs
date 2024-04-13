using wheel_wise.Model;

namespace wheel_wise.Service.Filters;

public class Filter : IFilter<Advertisement>
{
    public IEnumerable<Advertisement> FilterProducts(IEnumerable<Advertisement> ads, ISpecification<Advertisement> spec)
    {
        foreach (var ad in ads)
        {
            if (spec.IsSatisfied(ad))
            {
                yield return ad;
            }
        }
    }
    
}