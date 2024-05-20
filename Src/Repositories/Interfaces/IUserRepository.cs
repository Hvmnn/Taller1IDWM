namespace Taller1IDWM.Src.Repositories.Interfaces;

public interface IUserRepository
{
    Task<bool> UserExistsByEmailAsync(string email);
    Task<bool> UserExistsByRutAsync(string rut);
    Task<bool> UserExistsById(int id);
    Task<bool> SaveChangesAsync();
}