using Taller1IDWM.Src.DTOs.User;

namespace Taller1IDWM.Src.Repositories.Interfaces;

public interface IUserRepository
{
    Task<bool> UserExistsByEmailAsync(string email);
    Task<bool> UserExistsByRutAsync(string rut);
    Task<bool> SaveChangesAsync();
    Task<bool> EditUser (int id, EditUserDto editUser);
    Task<bool> EditPassword (EditPasswordDto editPassword);
}