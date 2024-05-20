namespace Taller1IDWM.Src.DTOs.User;

public class EditPasswordDto
{
    public required string Password {get;set;}
    public required string NewPassword {get;set;}
    public required string ConfirmNewPassword {get;set;}
}