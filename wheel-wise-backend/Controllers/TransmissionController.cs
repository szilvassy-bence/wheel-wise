using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wheel_wise.Model;
using wheel_wise.Service.Repository.TransmissionRepo;

namespace wheel_wise.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransmissionController : ControllerBase
{
    private readonly ILogger<TransmissionController> _logger;
    private readonly ITransmissionRepository _transmissionRepository;

    public TransmissionController(ILogger<TransmissionController> logger, ITransmissionRepository transmissionRepository)
    {
        _logger = logger;
        _transmissionRepository = transmissionRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transmission>>> GetAll()
    {
        return Ok(await _transmissionRepository.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Transmission>> GetById(int id)
    {
        var transmission = await _transmissionRepository.GetById(id);
        if (transmission == null)
        {
            return NotFound($"Transmission with id: {id} was not found.");
        }

        return Ok(transmission);
    }

    [HttpPost, Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add(Transmission transmission)
    {
        try
        {
            if (!User.IsInRole("Admin"))
            {
                return Forbid();
            }
            
            await _transmissionRepository.Add(transmission);
            return CreatedAtAction(nameof(GetAll), new { id = transmission.Id }, transmission);
        }
        catch(Exception e)
        {
            _logger.LogError(e, "Error adding transmission.");
            return StatusCode(500);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Transmission transmission)
    {
        try
        {
            if (id != transmission.Id)
            {
                return BadRequest();
            }

            var transmissionToUpdate = await _transmissionRepository.GetById(id);
            if (transmissionToUpdate is null)
            {
                return NotFound();
            }

            await _transmissionRepository.Update(transmission);
            return NoContent();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error changing transmission.");
            return StatusCode(500);
        }
    }

    [HttpDelete("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            if (!User.IsInRole("Admin"))
            {
                return Forbid();
            }
            
            var transmissionToDelete = await _transmissionRepository.GetById(id);
            if (transmissionToDelete is null)
            {
                return NotFound();
            }

            await _transmissionRepository.Delete(transmissionToDelete);
            return NoContent();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error deleting transmission.");
            return StatusCode(500);
        }
    }
}