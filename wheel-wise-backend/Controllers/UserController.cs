using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
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
    private readonly ILogger<UserController> _logger;

    public UserController(IUserRepository userRepository, ILogger<UserController> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
    {
        try
        {
            return Ok(await _userRepository.GetAll());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Could not process the request");
        }
    }
    
    [Authorize]
    [HttpGet("{userName}")]
    public async Task<ActionResult<User>> GetByName(string userName)
    {
        try
        {
            var authenticatedUserEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = await _userRepository.GetByName(userName);
            if (user == null)
            {
                return NotFound("User with given name cannot be found.");
            }
            if (authenticatedUserEmail != null)
            {
                if (authenticatedUserEmail != user.IdentityUser.Email && !User.IsInRole("Admin"))
                {
                    return Forbid();
                }    
            }
            return Ok(user);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return NotFound("Something went wrong");
        }
    }

    [HttpGet("{userName}/favorites"), Authorize]
    public async Task<ActionResult<IEnumerable<Advertisement?>>> GetFavoriteAdsByUserName(string userName)
    {
        var authenticatedUserEmail = User.FindFirst(ClaimTypes.Email)?.Value;
        var user = await _userRepository.GetByName(userName);
        if (user == null)
        {
            return NotFound("User with given name cannot be found.");
        }
        if (authenticatedUserEmail != null)
        {
            if (authenticatedUserEmail != user.IdentityUser.Email && !User.IsInRole("Admin"))
            {
                return Forbid();
            }    
        }
        return Ok(await _userRepository.GetFavoriteAdsByUserName(userName));
    }
    
    [HttpGet("{userName}/ads")]
    public async Task<ActionResult<IEnumerable<AdvertisementDTO?>>> GetAdsByUserName(string userName)
    {
        var authenticatedUserEmail = User.FindFirst(ClaimTypes.Email)?.Value;
        var user = await _userRepository.GetByName(userName);
        if (user == null)
        {
            return NotFound("User with given name cannot be found.");
        }
        if (authenticatedUserEmail != null)
        {
            if (authenticatedUserEmail != user.IdentityUser.Email && !User.IsInRole("Admin"))
            {
                return Forbid();
            }    
        }
        
        return Ok(await _userRepository.GetAdsByUserName(userName));
    }

    [HttpPatch("addfavorite/{userName}/{adId}"), Authorize]
    public async Task<IActionResult> AddFavoriteAdvertisement(string userName, int adId)
    {
        var authenticatedUserEmail = User.FindFirst(ClaimTypes.Email)?.Value;
        var user = await _userRepository.GetByName(userName);
        if (user == null)
        {
            return NotFound("User with given name cannot be found.");
        }
        if (authenticatedUserEmail != null)
        {
            if (authenticatedUserEmail != user.IdentityUser.Email)
            {
                return Forbid();
            }    
        }
        try
        {
            await _userRepository.AddFavoriteAdvertisement(userName, adId);
            return Ok("Advertisement added to favorites successfully.");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(500, "An error occurred while adding the advertisement to favorites.");
        }
    }

    [HttpDelete("removefavoritead/{userName}/{adId}"), Authorize]
    public async Task<IActionResult> RemoveFavoriteAdvertisement(string userName, int adId)
    {var authenticatedUserEmail = User.FindFirst(ClaimTypes.Email)?.Value;
        var user = await _userRepository.GetByName(userName);
        if (user == null)
        {
            return NotFound("User with given name cannot be found.");
        }
        if (authenticatedUserEmail != null)
        {
            if (authenticatedUserEmail != user.IdentityUser.Email)
            {
                return Forbid();
            }    
        }
        try
        {
            await _userRepository.RemoveFavoriteAdvertisement(userName, adId);
            return NoContent();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(500, "An error occurred while removing the advertisement from favorites.");
        }
    }

    [HttpPatch("{id}/edit"), Authorize]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] UserData userData)
    {
        await _userRepository.UpdateUser(id, userData);
        return Ok();
    }
}