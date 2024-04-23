using Microsoft.AspNetCore.Authorization;
using wheel_wise.Model;
using wheel_wise.Service.Repository;
using Microsoft.AspNetCore.Mvc;
using wheel_wise.ActionFilters;
using wheel_wise.Model.Filters;
using wheel_wise.Service.Filters;
using wheel_wise.Service.Repository.AdvertisementRepo;
using wheel_wise.Service.Repository.CarRepo;

namespace wheel_wise.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdsController : ControllerBase
{
    private readonly ILogger<AdsController> _logger;
    private readonly IAdvertisementRepository _advertisementRepository;

    public AdsController(ILogger<AdsController> logger, IAdvertisementRepository advertisementRepository)
    {
        _logger = logger;
        _advertisementRepository = advertisementRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Advertisement>>> GetAll()
    {
        Console.WriteLine(ModelState.ValidationState);
        return Ok(await _advertisementRepository.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Advertisement>> GetById(int id)
    {
        var ad = await _advertisementRepository.GetById(id);
        if (ad == null)
        {
            return NotFound($"Advertisement with id: {id} was not found.");
        }

        return Ok(ad);
    }

    [WarningFilter("Info")]
    [HttpPost]
    public async Task<ActionResult<Advertisement>> PostAd(Advertisement ad)
    {
        await _advertisementRepository.Add(ad);
        return CreatedAtAction(nameof(GetAll), new { id = ad.Id }, ad);
    }

    [WarningFilter("Info")]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAdById(int id, Advertisement ad)
    {
        if (id != ad.Id)
        {
            return BadRequest();
        }

        try
        {
            var adToUpdate = await _advertisementRepository.GetById(id);
            if (adToUpdate is null)
            {
                return NotFound();
            }
            
            await _advertisementRepository.UpdateById(id, ad);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCarById(int id)
    {
        var adToDelete = await _advertisementRepository.GetById(id);
        if (adToDelete is null)
        {
            return NotFound();
        }

        await _advertisementRepository.Delete(adToDelete);
        return NoContent();
    }

    [HttpPost("SimpleForm")]
    public async Task<ActionResult<IEnumerable<Advertisement>>> GetBySimpleFilter([FromBody] SimpleFilter simpleFilter)
    {
        return Ok(await _advertisementRepository.GetBySimpleFilter(simpleFilter));
    }
}