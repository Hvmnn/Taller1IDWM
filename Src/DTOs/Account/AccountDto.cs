using System.ComponentModel.DataAnnotations;
using Taller1IDWM.Src.Validations;

namespace Taller1IDWM.Src.DTOs.Account;

public class AccountDto
{
    [Rut]
    public required string Rut {get;set;}

    [StringLength(255, MinimumLength = 8, ErrorMessage = "Name must be between 8 and 255 characters")]
    public required string Name {get;set;}

    [Birthdate]
    public required DateTime Birthdate {get;set;}

    [EmailAddress]
    public required string Email {get;set;}

    public required string Gender{get;set;}

    public required int IsEnabled{get;set;}

    public required string Token {get;set;}
}