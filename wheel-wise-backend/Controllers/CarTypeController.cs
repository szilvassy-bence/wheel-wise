using Microsoft.AspNetCore.Mvc;
using wheel_wise.Model;
using wheel_wise.Service.Repository.CarTypeRepo;

namespace wheel_wise.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarTypeController: ControllerBase
{
    private ILogger<CarTypeController> _logger;
    private ICarTypeRepository _carTypeRepository;

    CarTypeController(ILogger<CarTypeController> logger, ICarTypeRepository carTypeRepository)
    {
        _logger = logger;
        _carTypeRepository = carTypeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var carTypeList = await _carTypeRepository.GetAll();
            return Ok(carTypeList);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occured while trying to list all car types.");
            return StatusCode(500, "An error occured while trying to list all car types.");
        }
    }

    [HttpGet("/getbybrandandcolor/{brand}/{color}")]
    public async Task<IActionResult> GetByBrand(string brand, string model)
    {
        try
        {
            var carType = await _carTypeRepository.GetByCarModel(brand, model);
            if (carType == null)
            {
                return NotFound("No car type with this brand and model found!");
            }

            return Ok(carType);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occured while trying to get a specific car type.");
            return StatusCode(500, "An error occured while trying to get a specific car type.");
        }
    }

    [HttpPost("/add")]
    public async Task<IActionResult> AddCarType(CarType carType)
    {
        try
        {
            _carTypeRepository.Add(carType);
            bool carTypeAdded = await _carTypeRepository.GetByCarModel(carType.Brand, carType.Model) != null;
            if (!carTypeAdded)
            {
                throw new NullReferenceException("Car type wasn't added!");
            }
            return Ok($"{carType} added");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occured while trying to ADD a car type.");
            return StatusCode(500, "An error occured while trying to ADD a car type.");
        }
    }

    [HttpPost("/delete/{id}")]
    public async Task<IActionResult> DeleteCarType(int id)
    {
        try
        {
            var carType = await _carTypeRepository.GeById(id);
            if (carType == null)
            {
                return NotFound("Can't find the car type to delete");
            }

            _carTypeRepository.Delete(carType);
            return Ok("Car type deleted successfully!");

        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occured while trying to delete a car type.");
            return StatusCode(500, "An error occured while trying to delete a car type.");
        }
    }
}