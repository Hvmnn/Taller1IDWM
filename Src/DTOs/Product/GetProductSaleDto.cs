using Taller1IDWM.Src.Models;

namespace Taller1IDWM.Src.DTOs.Product;

public class GetProductSaleDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Price { get; set; }
    public required CategoryDto Category {get; set; }
}