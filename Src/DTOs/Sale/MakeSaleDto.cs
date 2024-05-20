using System.ComponentModel.DataAnnotations;

namespace Taller1IDWM.Src.DTOs.Product;
public class MakeSaleDto
{
    [RegularExpression(@"^[0-9]+$", ErrorMessage = "El stock debe ser un número entero")]
    [Range(1, 99999, ErrorMessage = "El stock debe ser un entero no negativo menor que 100.000")]
    public required int SaleStock { get; set; }
    
    [Required]
    public required int ProductId {get;set; }

    [Required]
    public required int UserId {get; set; }
}