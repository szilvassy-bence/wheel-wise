using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wheel_wise.Model;
using wheel_wise.Service.Repository.EquipmentRepo;

namespace wheel_wise.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class EquipmentController : ControllerBase
{
    private readonly ILogger<EquipmentController> _logger;
    private readonly IEquipmentRepository _equipmentRepository;

    public EquipmentController(ILogger<EquipmentController> logger, IEquipmentRepository equipmentRepository)
    {
        _logger = logger;
        _equipmentRepository = equipmentRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Equipment>>> GetAll()
    {
        try
        {
            _logger.LogInformation("Returning All Equipments.");
            var equipments = await _equipmentRepository.GetAll();
            return Ok(equipments);
        }
        catch (Exception e)
        {
            _logger.LogInformation(e, "Error getting all equipment.");
            return NotFound("Error getting all equipment.");
        }
    }
    
    [HttpPost, Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddEquipment(Equipment equipment)
    {
        try
        {
            if (!User.IsInRole("Admin"))
            {
                return Forbid();
            }
            _logger.LogInformation("Adding equipment to repo.");
            await _equipmentRepository.Add(equipment);
            return CreatedAtAction(nameof(GetAll), new { id = equipment.Id }, equipment);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error adding equipment.");
            return StatusCode(500);
        }
    }
    
    [HttpDelete("{equipmentId}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteEquipmentById(string equipmentId)
    {
        try
        {
            if (!User.IsInRole("Admin"))
            {
                return Forbid();
            }
            _logger.LogInformation("Deleting Equipment with id {equipmentId}", equipmentId);

            if (Int32.TryParse(equipmentId, out int idInt))
            {
                var equipment = await _equipmentRepository.GetById(idInt);
                if (equipment != null)
                {
                    await _equipmentRepository.Delete(equipment);
                    return NoContent();
                }
            }
            
            return NotFound("Equipment does not exist with this id");
            
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting equipment with ID {equipmentId}", equipmentId);
            return StatusCode(500, $"Error getting equipment with ID {equipmentId}");
        }
    }
    
    //UPDATE NEEDS TO BE ADDED
}