using Taller1IDWM.Src.DTOs.Product;
using Taller1IDWM.Src.DTOs.User;

namespace Taller1IDWM.Src.Models;
public class GetUserSaleDto
{
    public int Id { get; set; }
    public required DateTime SaleDate {get; set;}
    public required GetProductSaleDto Product {get; set; }
    public required int SaleStock { get; set; }
    public int Total {get; set; }
}