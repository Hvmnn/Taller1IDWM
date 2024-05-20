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

    public async Task<bool> EditUser(int id, EditUserDto editUser)
    {
        var existUser = await _dataContext.Users.FindAsync(id);
        if(existUser == null)
        {
            return false;
        }

        existUser.Name = editUser.Name ?? existUser.Name;
        existUser.Gender = editUser.Gender ?? existUser.Gender;
        existUser.Birthdate = editUser.Birthdate != default ? editUser.Birthdate : existUser.Birthdate;
        
        _dataContext.Entry(existUser).State = EntityState.Modified;
        await _dataContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> EditPassword(int id, EditPasswordDto editPassword)
    {
        var existUser = await _dataContext.Users.FindAsync(id);
        if(existUser == null)
        {
            return false;
        }

        if (!BCrypt.Net.BCrypt.Verify(editPassword.Password, existUser.Password))
        {
            return false;
        }

        if (editPassword.NewPassword != editPassword.ConfirmNewPassword)
        {
            return false;
        }

        existUser.Password = BCrypt.Net.BCrypt.HashPassword(editPassword.NewPassword);

        _dataContext.Entry(existUser).State = EntityState.Modified;
        await _dataContext.SaveChangesAsync();

        return true;

    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        var users = await _dataContext.Users.Where(u => u.RoleId == 2).ToListAsync();
        return users;
    }

    public async Task<bool> EnableDisableUser(int id, EnableDisableUserDto enableDisableUser)
    {
        var existUser = await _dataContext.Users.FindAsync(id);
        if(existUser == null)
        {
            return false;
        }

        if(enableDisableUser.IsEnabled != 0 && enableDisableUser.IsEnabled !=1)
        {
            throw new ArgumentException("Invalid value for IsEnabled");
        }

        existUser.IsEnabled = enableDisableUser.IsEnabled;

        _dataContext.Entry(existUser).State = EntityState.Modified;
        await _dataContext.SaveChangesAsync();

        return true;
    }
} 
    }

    public async Task<bool> UserExistsById(int id)
    {
        return await _dataContext.Users.AnyAsync(x => x.Id == id);
    }
}