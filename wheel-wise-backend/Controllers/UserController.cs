using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using wheel_wise.Model;
using wheel_wise.Model.DTO;
using wheel_wise.Service.Repository.UserRepo;

namespace wheel_wise.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("{name}")]
    public async Task<ActionResult<User>> GetByName(string name)
    {
        try
        {
            var user = await _userRepository.GetByName(name);
            if (user == null)
            {
                return NotFound("User with given name cannot be found.");
            }


            return Ok(user);
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
            return StatusCode(500, "An error occurred while trying to get user.");
        }
    }

    [HttpGet("{userName}/favorites")]
    public async Task<ActionResult<IEnumerable<Advertisement?>>> GetFavoriteAdsByUserName(string userName)
    {
        return Ok(await _userRepository.GetFavoriteAdsByUserName(userName));
    }
    
    [HttpGet("{userName}/ads")]
    public async Task<ActionResult<IEnumerable<Advertisement?>>> GetAdsByUserName(string userName)
    {
        return Ok(await _userRepository.GetAdsByUserName(userName));
    }

    [HttpPatch("/addfavoritead/{userName}/{adId}")]
    public async Task<IActionResult> AddFavAd(string userName, int adId)
    {
        try
        {
            await _userRepository.AddFavoriteAdvertisement(userName, adId);
            return Ok("Advertisement added to favorites successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return StatusCode(500, "An error occurred while adding the advertisement to favorites.");
        }
    }

    [HttpPatch("{id}/edit")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody]UserData userData)
    {
        await _userRepository.UpdateUser(id, userData);
        return Ok();
    }
}