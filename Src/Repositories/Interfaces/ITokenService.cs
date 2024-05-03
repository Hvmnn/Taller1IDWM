namespace Taller1IDWM.Src.Repositories.Interfaces;

public interface ITokenService
{
    string CreateToken(string rut, string nameRole);
}