namespace Taller1IDWM.Src.DTOs.User;

public class EditPasswordDto
{
    public required string password {get;set;}
    public required string newPassword {get;set;}
    public required string confirmNewPassword {get;set;}
}