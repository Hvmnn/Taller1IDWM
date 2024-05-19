using Microsoft.AspNetCore.Mvc;
using Taller1IDWM.Src.DTOs.Account;
using Taller1IDWM.Src.Repositories.Interfaces;

namespace Taller1IDWM.Src.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController (IAccountRepository accountRepository, IUserRepository userRepository) : ControllerBase
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IAccountRepository _accountRepository = accountRepository;

    [HttpPost("register")]
    public async Task<IResult> Register(RegisterDto registerDto)
    {
        if(await _userRepository.UserExistsByEmailAsync(registerDto.Email) || await _userRepository.UserExistsByRutAsync(registerDto.Rut))
        {
            return TypedResults.BadRequest("User already exists");
        }

        await _accountRepository.AddAccountAsync(registerDto);

        if(!await _accountRepository.SaveChangesAsync())
        {
            return TypedResults.BadRequest("Failed to save user");
        }

        AccountDto? accountDto = await _accountRepository.GetAccountAsync(registerDto.Email);

        return TypedResults.Ok(accountDto);
    }

    [HttpPost("login")]
    public async Task<IResult> Login(LoginDto loginDto)
    {
        CredentialDto? credentialDto = await _accountRepository.GetCredentialAsync(loginDto.Email);

        if(credentialDto is null)
        {
            return TypedResults.BadRequest("Credentials are invalid");            
        }

        var result = BCrypt.Net.BCrypt.Verify(loginDto.Password, credentialDto.Password);
        if(!result)
        {
            return TypedResults.BadRequest("Credentials are invalid");
        }

        AccountDto? accountDto = await _accountRepository.GetAccountAsync(loginDto.Email);

        if (accountDto == null || accountDto.IsEnabled == 0)
        {
            return TypedResults.BadRequest("User is disabled");
        }

        return TypedResults.Ok(accountDto);
    }
}