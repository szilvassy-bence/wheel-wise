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
        
        return Ok(await _userRepository.GetByName(name));
    }

    [HttpPatch("{id}/edit")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody]UserData userData)
    {
        await _userRepository.UpdateUser(id, userData);
        return Ok();
    }
}