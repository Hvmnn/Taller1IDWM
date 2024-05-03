namespace Taller1IDWM.Src.Models;

public class User
{
    public int Id {get; set;}
    public required string Rut {get;set;}
    public required string Name {get;set;}
    public required DateTime Birthdate {get;set;}
    public required string Email {get;set;}
    public required string Gender {get;set;}
    public required string Password {get; set;}
    public int RoleId {get; set;}
    public required Role Role {get;set;}

}
