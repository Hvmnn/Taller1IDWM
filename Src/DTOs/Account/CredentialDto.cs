namespace Taller1IDWM.Src.DTOs.Account;

public class CredentialDto
{
    public required byte[] PasswordHash {get;set;}
    public required byte[] PasswordSalt {get;set;}
}