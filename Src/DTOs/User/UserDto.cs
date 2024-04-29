using System.Diagnostics.CodeAnalysis;

namespace Taller1IDWM.Src.DTOs.User;

public class UserDto
{
    public required string Rut {get;set;}
    public required string Name {get;set;}
    public required DateTime Birthdate {get;set;}
    public required string Email {get;set;}
    public required string Gender {get;set;} 
}