using Taller1IDWM.Src.Data;
using AutoMapper;
using Taller1IDWM.Src.Repositories.Interfaces;
using Taller1IDWM.Src.DTOs.Account;
using Microsoft.EntityFrameworkCore;
using Taller1IDWM.Src.Models;

namespace Taller1IDWM.Src.Repositories.Implements;

public class AccountRepository(DataContext dataContext, IMapper mapper, ITokenService tokenService) : IAccountRepository
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    private readonly ITokenService _tokenService = tokenService;


    public async Task<bool> AccountExistsByEmailAsync(string email)
    {
        email = email.ToLower();
        return await _dataContext.Users.AnyAsync(x => x.Email == email);
    }

    public async Task AddAccountAsync(RegisterDto registerDto)
    {
        Role clientRole = await _dataContext.Roles.FirstAsync(x => x.Name == "Client");

        User user = 
            new()
            {
            Rut = registerDto.Rut.ToLower(),
            Name = registerDto.Name.ToLower(),
            Birthdate = registerDto.Birthdate,
            Email = registerDto.Email.ToLower(),
            Gender = registerDto.Gender.ToLower(),
            Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
            Role = clientRole
            };
        
        await _dataContext.Users.AddAsync(user);
    }

    public async Task<AccountDto?> GetAccountAsync(string email)
    {
        email = email.ToLower();
        User? user = await _dataContext.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Email == email);

        if(user == null)
        {
            return null;
        }

        AccountDto accountDto =
            new()
            {
                Rut = user.Rut,
                Name = user.Name,
                Birthdate = user.Birthdate,
                Email = user.Email,
                Gender = user.Gender,
                Token = _tokenService.CreateToken(user.Rut, user.Role.Name)
            };

        return accountDto;
    }

    public async Task<CredentialDto?> GetCredentialAsync(string email)
    {
        email = email.ToLower();
        User? user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Email == email);

        return _mapper.Map<CredentialDto>(user);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return 0 < await _dataContext.SaveChangesAsync();
    }
}