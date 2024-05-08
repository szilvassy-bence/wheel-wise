using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FuelType>>> GetAll()
    {
        try
        {
            _logger.LogInformation("Returning All fuel types.");
            var equipments = await _fuelTypeRepository.GetAll();
            return Ok(equipments);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting all fuel types.");
            return NotFound("Error getting all fuel types.");
        }
    }
    
    [HttpPost, Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddFuelType(FuelType fuelType)
    {
        try
        {
            if (!User.IsInRole("Admin"))
            {
                return Forbid();
            }
            
            _logger.LogInformation("Adding fuelType to repo.");
            await _fuelTypeRepository.Add(fuelType);
            return CreatedAtAction(nameof(GetAll), new { id = fuelType.Id }, fuelType);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error adding fuelType.");
            return StatusCode(500);
        }
    }
    
    [HttpDelete("{fuelTypeId}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteFuelTypeById(string fuelTypeId)
    {
        try
        {
            if (!User.IsInRole("Admin"))
            {
                return Forbid();
            }
            
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
            _logger.LogError(e, "Error getting fuelType with ID {fuelTypeId}", fuelTypeId);
            return StatusCode(500, $"Error getting fuelType with ID {fuelTypeId}");
        }
    }
}