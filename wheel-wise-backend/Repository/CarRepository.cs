using System.Data;
using wheel_wise.Model;

namespace wheel_wise.Repository;

using Microsoft.AspNetCore.Mvc;


public class CarRepository
{

    private IList<Car> _cars;

    public CarRepository()
    {
        _cars = new List<Car>()
        {
            new Car(1, "Civic", "Honda", "green"),
            new Car(1, "Accord", "Honda", "red")
        };
    }

    public IEnumerable<Car> GetCars()
    { 
        
        return _cars;
    }

    public Car GetCarById(int id)
    {
        return _cars.First(x => x.Id == id);
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