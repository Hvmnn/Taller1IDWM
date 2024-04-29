using System.ComponentModel.DataAnnotations;
using System.Data;
using Taller1IDWM.Src.Validations;

namespace Taller1IDWM.Src.DTOs.Account;

public class RegisterDto
{
    [Rut]
    public required string Rut {get;set;}

    [StringLength(255, MinimumLength = 8, ErrorMessage = "Name must be between 8 and 255 characters")]
    public required string Name {get;set;}

    [Birthdate]
    public required DateTime Birthdate {get;set;}

    [EmailAddress]
    public required string Email {get;set;}

    public required string Gender {get;set;}

    [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters")]
    public required string Password {get;set;}

    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public required string ConfirmPassword { get; set; }

}