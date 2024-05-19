using System.Collections;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taller1IDWM.Src.DTOs.User;
using Taller1IDWM.Src.Models;
using Taller1IDWM.Src.Repositories.Implements;
using Taller1IDWM.Src.Repositories.Interfaces;

namespace Taller1IDWM.Src.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class AdminController (IUserRepository userRepository, IMapper mapper): ControllerBase
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;

    [HttpGet("users")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        var users = await _userRepository.GetUsers();
        var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
        return Ok(userDtos);
    }

    [HttpPut("enable-disable/{id}")]
    public async Task<IActionResult> EnableDisableUser(int id, [FromBody] EnableDisableUserDto enableDisableUser)
    {
        if (enableDisableUser.IsEnabled != 0 && enableDisableUser.IsEnabled != 1)
        {
            return BadRequest("Invalid value for IsEnabled");
        }

        var result = await _userRepository.EnableDisableUser(id, enableDisableUser);
        if(result)
        {
            return Ok("User status updated succesfully");
        }

        return NotFound("User not found");
    }

}