using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller1IDWM.Src.Models;
public class ProductDto
{
    [StringLength(64, MinimumLength = 10, ErrorMessage = "El nombre debe tener entre 10 a 64 caracteres")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El nombre debe ser una cadena alfabéfica")]
    public required string Name { get; set; }

    [RegularExpression(@"^[0-9]+$", ErrorMessage = "El precio debe ser un número entero")]
    [Range(1, 99999999, ErrorMessage = "El precio debe ser un entero positivo menor que 100.000.000")]
    public required int Price { get; set; }

    [RegularExpression(@"^[0-9]+$", ErrorMessage = "El stock debe ser un número entero")]
    [Range(1, 99999, ErrorMessage = "El stock debe ser un entero no negativo menor que 100.000")]
    public required int Stock { get; set; }

    [Required]
    public required string ImageUrl { get; set; }
    
    [Required]
    public required int CategoryId {get;set; }
}