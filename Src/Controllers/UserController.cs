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
public class UserController (IUserRepository userRepository, IMapper mapper): ControllerBase
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;

    [HttpPut("edit-user/{id}")]
    public async Task<string> EditUser(int id, [FromBody] EditUserDto editUser)
    {
        if(await _userRepository.EditUser(id, editUser))
        {
            return "User updated succesfully";
        }

        return "User not found"; 
    }

    [HttpPut("edit-password/{id}")]
    public async Task<string> EditPassword(int id, [FromBody] EditPasswordDto editPassword)
    {
        if(await _userRepository.EditPassword(id, editPassword))
        {
            return "Password updated succesfully";
        }

        return "User not found";
    }

}