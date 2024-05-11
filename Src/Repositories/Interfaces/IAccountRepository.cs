using Taller1IDWM.Src.DTOs.Account;
namespace Taller1IDWM.Src.Repositories.Interfaces;

public interface IAccountRepository
{
    Task<bool> AccountExistsByEmailAsync(string email);
    Task AddAccountAsync(RegisterDto registerDto);
    Task<AccountDto?> GetAccountAsync(string email);
    Task<CredentialDto?> GetCredentialAsync(string email);
    Task<bool> SaveChangesAsync();
}