namespace Taller1IDWM.Src.Models;
public class Sale
{
    public int Id { get; set; }
    public required int SaleStock { get; set; }
    public required int Total {get; set; }
    public required DateTime SaleDate {get; set; }
    public int UserId {get; set;}
    public required User User {get;set;}
    public int ProductId {get; set;}
    public required Product Product {get;set;}
}