using Taller1IDWM.Src.Models;

namespace Taller1IDWM.Src.DTOs.Product;

public class GetProductDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Price { get; set; }
    public required int Stock { get; set; }
    public required string ImageUrl { get; set; }
    public required Category Category {get; set;}
}