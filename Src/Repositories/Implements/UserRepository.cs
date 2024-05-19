using Microsoft.EntityFrameworkCore;
using Taller1IDWM.Src.Data;
using Taller1IDWM.Src.DTOs.User;
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

    public async Task<bool> UserExistsByRutAsync(string rut)
    {
        return await _dataContext.Users.AnyAsync(user => user.Rut == rut);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return 0 < await _dataContext.SaveChangesAsync();
    }

    public Task<bool> EditUser(int id, EditUserDto editUser)
    {
        throw new NotImplementedException();
    }

    public Task<bool> EditPassword(EditPasswordDto editPassword)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        var users = await _dataContext.Users.Where(u => u.RoleId == 2).ToListAsync();
        return users;
    }
} 