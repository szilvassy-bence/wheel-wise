using wheel_wise.Model;
using wheel_wise.Repository;
using Microsoft.AspNetCore.Mvc;

namespace wheel_wise.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetCars()
    {
        var repository = new CarRepository();
        return Ok(repository.GetCars());
    }

    [HttpGet("{id}")]
    public ActionResult<Car> GetCarById(int id)
    {
        var repository = new CarRepository();
        return Ok(repository.GetCarById(id));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Car> PostCar(Car car)
    {
        var repository = new CarRepository();
        repository.PostCar(car);
        var index = repository.PostCar(car);
        car.Id = index;
        return CreatedAtAction(nameof(PostCar), new { id = index }, car);
        //return Ok(repository.PostCar(car));
    }

    [HttpPut("{id}")]
    public ActionResult<Car> PutCarById(int id, Car car)
    {
        var repository = new CarRepository();
        return Ok(repository.PutCarById(id, car));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCarById(int id)
    {
        var repository = new CarRepository();
        repository.DeleteCarById(id);
        return Ok();
    }
}