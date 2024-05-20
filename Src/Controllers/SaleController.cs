using Microsoft.AspNetCore.Mvc;
using Taller1IDWM.Src.DTOs.Product;
using Taller1IDWM.Src.Repositories.Interfaces;

namespace Taller1IDWM.Src.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SaleController(
    ISaleRepository saleRepository, IUserRepository userRepository, IProductRepository productRepository) : ControllerBase
{
    private readonly ISaleRepository _saleRepository = saleRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IProductRepository _productRepository = productRepository;

/// <summary>
/// realiza una venta, dado los parámetros ingresados por le usuario
/// </summary>
/// <param name="saleDto">datos de la venta a registrar</param>
/// <returns>bad request si hay errores en los parámetros ingresados, created si se logra registrar la venta</returns>
    [HttpPost]
    public async Task<IResult> MakeSale(MakeSaleDto saleDto)
    {

        if (!await _userRepository.UserExistsById(saleDto.UserId))
        {
            return TypedResults.BadRequest("Usuario ingresado no se encuentra en el sistema");
        }

        if (!await _productRepository.ProductExistsById(saleDto.ProductId))
        {
            return TypedResults.BadRequest("Producto ingresado no se encuentra en el sistema");
        }

        if (!await _productRepository.reduceStock(saleDto.ProductId, saleDto.SaleStock))
        {
            return TypedResults.BadRequest("Producto ingresado no tiene suficiente stock");
        }

        var sale = await _saleRepository.MakeSale(saleDto);

        return TypedResults.Created($"/sale/{sale.Id}", sale);

    }
/// <summary>
/// obtiene todas las comprar registradas en el sistema
/// </summary>
/// <returns>lista de las compras registradas</returns>
    [HttpGet]
    public async Task<IResult> GetSales()
    {

        var sales = await _saleRepository.GetSales();
        return TypedResults.Ok(sales);
    }

    /// <summary>  
    /// obtiene todas las compras realizadas por un usuario  
    /// </summary>  
    /// <param name="userId">id del usuario</param>  
    /// <returns>"BadRequest" si no se encuenta el usuario, lista de sus compras si encuentra el usuario </returns> 
    [HttpGet("user/{userId}")]
    public async Task<IResult> GetSales(int userId)
    {
        if (!await _userRepository.UserExistsById(userId))
        {
            return TypedResults.BadRequest("Usuario ingresado no se encuentra en el sistema");
        }

        var sales = await _saleRepository.GetSales(userId);
        return TypedResults.Ok(sales);
    }
}