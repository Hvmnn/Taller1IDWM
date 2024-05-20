using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taller1IDWM.Src.DTOs.Product;
using Taller1IDWM.Src.Repositories.Interfaces;

namespace Taller1IDWM.Src.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository) : ControllerBase
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

/// <summary>
/// Agrega un producto al sistema, ingresado por el usuario
/// </summary>
/// <param name="addProductDto">producto a agregar</param>
/// <returns>bad request si ocurre algun error al intentar agregar el producto, created si se logra agregar</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IResult> AddProduct(AddEditProductDto addProductDto)
    {
        if (await _productRepository.ProductExistsByNameAndType(addProductDto))
        {
            return TypedResults.BadRequest("Producto con el mismo nombre y tipo ya existe");
        }

        if (null == await _categoryRepository.GetCategoryById(addProductDto.CategoryId))
        {
            return TypedResults.BadRequest("Categoría ingresada no existe");
        }

        await _productRepository.AddProduct(addProductDto);

        if (await _productRepository.SaveChangesAsync())
        {
            return TypedResults.Created("Producto agregado exitosamente");
        }

        return TypedResults.BadRequest("Error agregando producto");
    }
/// <summary>
/// Elimina un producto del sistema, dado su id
/// </summary>
/// <param name="id">id dle producto a eliminar</param>
/// <returns>not found si no encuentra la id, bad request si falla la eliminación, ok si se logra eliminar</returns>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IResult> DeleteProduct(int id)
    {
        if (false == await _productRepository.DeleteProduct(id))
        {
            return TypedResults.NotFound("No se encontró el producto a eliminar");
        }

        if (await _productRepository.SaveChangesAsync())
        {
            return TypedResults.Ok("el producto se eliminó correctamente");
        }

        return TypedResults.BadRequest("Error eliminando producto");
    }
/// <summary>
/// retorna una lista con todos los productos registrados en el sistema
/// </summary>
/// <returns>lista de los productos</returns>
    [HttpGet]
    [Authorize]
    public async Task<IResult> GetProducts()
    {

        var products = await _productRepository.GetProducts();
        return TypedResults.Ok(products);
    }
/// <summary>
/// edita los cmapos de un producto, dado su id
/// </summary>
/// <param name="id">id del producto</param>
/// <param name="editProductDto">producto con los campos a modificar</param>
/// <returns>not found si no se encuentra la id, bad request si hay errores en los campos a modificar, ok si se modifica</returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IResult> EditProduct(int id, AddEditProductDto editProductDto)
    {
        if (null == await _categoryRepository.GetCategoryById(editProductDto.CategoryId))
        {
            return TypedResults.BadRequest("Categoría ingresada no existe");
        }
        
        if (false == await _productRepository.EditProduct(id, editProductDto))
        {
            return TypedResults.NotFound("No se encontró el producto a editar");
        }

        if (await _productRepository.SaveChangesAsync())
        {
            return TypedResults.Ok("el producto se editó correctamente");
        }

        return TypedResults.BadRequest("Error editando producto");
    }
}