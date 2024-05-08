using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wheel_wise.Model;
using wheel_wise.Service.Repository.CarTypeRepo;
using wheel_wise.Service.Repository.UserRepo;

namespace wheel_wise.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarTypeController: ControllerBase
{
    private ILogger<CarTypeController> _logger;
    private ICarTypeRepository _carTypeRepository;
    private IUserRepository _userRepository;

    public CarTypeController(ILogger<CarTypeController> logger, ICarTypeRepository carTypeRepository, IUserRepository userRepository)
    {
        _logger = logger;
        _carTypeRepository = carTypeRepository;
        _userRepository = userRepository;
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
    
    //getbyid endpoint needed!!

    [HttpGet("getbybrandandcolor/{brand}/{color}")]
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

    [HttpPost, Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddCarType(CarType carType)
    {
        try
        {
            if (!User.IsInRole("Admin"))
            {
                return Forbid();
            }

            await _carTypeRepository.Add(carType);
            
            return CreatedAtAction(nameof(GetAll), new { id = carType.Id }, carType);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occured while trying to ADD a car type.");
            return StatusCode(500, "An error occured while trying to ADD a car type.");
        }
    }

    [HttpDelete("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteCarType(int id)
    {
        try
        {
            if (!User.IsInRole("Admin"))
            {
                return Forbid();
            }
            
            var carType = await _carTypeRepository.GeById(id);
            if (carType == null)
            {
                return NotFound("Can't find the car type to delete");
            }

            await _carTypeRepository.Delete(carType);
            return NoContent();

        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occured while trying to delete a car type.");
            return StatusCode(500, "An error occured while trying to delete a car type.");
        }
    }
}