using wheel_wise.Model;
using wheel_wise.Service.Repository;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<ActionResult<IEnumerable<Advertisement>>> GetAds()
    {
        return Ok(await _advertisementRepository.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Advertisement>> GetAdById(int id)
    {
        var ad = await _advertisementRepository.GetById(id);
        if (ad == null)
        {
            return NotFound($"Advertisement with id: {id} was not found.");
        }

        return Ok(ad);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Advertisement>> PostAd(Advertisement ad)
    {
        _advertisementRepository.Add(ad);
        return CreatedAtAction(nameof(GetAds), new { id = ad.Id }, ad);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAdById(int id, Advertisement ad)
    {
        if (id != ad.Id)
        {
            return BadRequest();
        }
        var adToUpdate = await _advertisementRepository.GetById(id);
        if (adToUpdate is null)
        {
            _advertisementRepository.Update(ad);
        }
        return NoContent();
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
}