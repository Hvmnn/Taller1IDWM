using Microsoft.EntityFrameworkCore;
using Taller1IDWM.Src.Data;
using Taller1IDWM.Src.Models;
using Taller1IDWM.Src.Repositories.Interfaces;

namespace Taller1IDWM.Src.Repositories.Implements;

public class UserRepository(DataContext dataContext) : IUserRepository
{
    private readonly DataContext _dataContext = dataContext;

    public async Task<bool> UserExistsByEmailAsync(string email)
    {
        return await _dataContext.Users.AnyAsync(user => user.Email == email);
    }
} 