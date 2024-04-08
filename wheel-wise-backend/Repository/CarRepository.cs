using System.Data;
using System.Reflection;
using wheel_wise.Model;
using wheel_wise.Service;

namespace wheel_wise.Repository;

using Microsoft.AspNetCore.Mvc;


public class CarRepository
{

    private IList<Car> _cars;

    public CarRepository()
    {
        /*_cars = new List<Car>()
        {
            new Car{Brand = "audi", Color = "balck", CarType = "valami", Price = 200000},
        };*/
    }

    public IEnumerable<Car> GetCars()
    { 
        
        return _cars;
    }

    public Car GetCarById(int id)
    {
        return _cars.First(x => x.Id == id);
    }

    public IEnumerable<Car> FilterCars(FilterModel filterModel)
    {
        List<ISpecification<Car>> carSpecifications = new List<ISpecification<Car>>();
        PropertyInfo[] properties = typeof(FilterModel).GetProperties();
        
        if (filterModel.Brand != null)
        {
            carSpecifications.Add(new BrandSpecification(filterModel.Brand));
        }
        if (filterModel.Type != null)
        {
            carSpecifications.Add(new TypeSpecification(filterModel.Type));
        }
        if (filterModel.Color != null)
        {
            carSpecifications.Add(new ColorSpecification(filterModel.Color));
        }
        if (filterModel.PriceRange != null)
        {
            carSpecifications.Add(new PriceSpecification(filterModel.PriceRange));
        }

        return new List<Car>();
    }

    
    public int PostCar(Car car)
    {
        return 0;
    }

    public int PutCarById(int id, Car car)
    {
        return 0;
    }

    public void DeleteCarById(int id)
    {
        return;
    }
    
}