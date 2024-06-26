using Taller1IDWM.Src.DTOs.User;
using Taller1IDWM.Src.Models;

namespace Taller1IDWM.Src.Repositories.Interfaces;

public interface IUserRepository
{
    Task<bool> UserExistsByEmailAsync(string email);
    Task<bool> UserExistsByRutAsync(string rut);
    Task<bool> UserExistsById(int id);
    Task<bool> SaveChangesAsync();
    Task<bool> EditUser (int id, EditUserDto editUser);
    Task<bool> EditPassword (int id, EditPasswordDto editPassword);
    Task<IEnumerable<User>> GetUsers();
    Task<bool> EnableDisableUser(int id, EnableDisableUserDto enableDisableUser);
}