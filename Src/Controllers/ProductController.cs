using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taller1IDWM.Src.Models;
using Taller1IDWM.Src.Repositories.Interfaces;

namespace courses_dotnet_api.Src.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository) : ControllerBase
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    [HttpPost]
    public async Task<IResult> AddProduct(ProductDto addProductDto)
    {
        if (await _productRepository.ProductExistsByName(addProductDto.Name))
        {
            return TypedResults.BadRequest("Producto con el mismo nombre ya existe");
        }

        if (null == await _categoryRepository.GetCategoryById(addProductDto.CategoryId)){
            return TypedResults.BadRequest("Categoría ingresada no existe");
        }

        await _productRepository.AddProduct(addProductDto);
        await _productRepository.SaveChangesAsync();
        return TypedResults.Created("Producto agregado exitosamente");
    }
}