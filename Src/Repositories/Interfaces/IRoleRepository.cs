using Taller1IDWM.Src.Models;

namespace Taller1IDWM.Src.Repositories.Interfaces;
public interface IRoleRepository
{
    Task<Role?> GetRoleById(int id);

    Task<Role?> GetRoleByName(string name);
}