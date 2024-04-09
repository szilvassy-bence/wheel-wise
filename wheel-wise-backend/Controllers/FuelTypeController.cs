using Microsoft.AspNetCore.Mvc;
using wheel_wise.Model;
using wheel_wise.Service.Repository.FuelTypeRepo;

namespace wheel_wise.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class FuelTypeController : ControllerBase
{
    private readonly ILogger<FuelTypeController> _logger;
    private readonly IFuelTypeRepository _fuelTypeRepository;

    public FuelTypeController(ILogger<FuelTypeController> logger, IFuelTypeRepository fuelTypeRepository)
    {
        _logger = logger;
        _fuelTypeRepository = fuelTypeRepository;
    }

    [HttpGet("GetAllFuelType")]
    public async Task<ActionResult<IEnumerable<FuelType>>> GetAllFuelType()
    {
        try
        {
            _logger.LogInformation("Returning All fuel types.");
            var equipments = await _fuelTypeRepository.GetAll();
            return Ok(equipments);
        }
        catch (Exception e)
        {
            _logger.LogInformation(e, "Error getting all fuel types.");
            return NotFound("Error getting all fuel types.");
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddFuelType(FuelType fuelType)
    {
        try
        {
            _logger.LogInformation("Adding fuelType to repo.");
            await _fuelTypeRepository.Add(fuelType);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogInformation(e, "Error adding fuelType.");
            return StatusCode(500);
        }
    }
    
    [HttpDelete("{fuelTypeId}")]
    public async Task<IActionResult> DeleteFuelTypeById(string fuelTypeId)
    {
        try
        {
            _logger.LogInformation("Deleting Equipment with id {fuelTypeId}", fuelTypeId);

            if (Int32.TryParse(fuelTypeId, out int idInt))
            {
                var equipment = await _fuelTypeRepository.GetById(idInt);
                if (equipment != null)
                {
                    await _fuelTypeRepository.Delete(equipment);
                    return NoContent();
                }
            }
            
            return NotFound("fuelType does not exist with this id");
            
        }
        catch (Exception e)
        {
            _logger.LogInformation(e, "Error getting fuelType with ID {fuelTypeId}", fuelTypeId);
            return StatusCode(500, $"Error getting fuelType with ID {fuelTypeId}");
        }
    }
}