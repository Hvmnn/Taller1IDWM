using Microsoft.AspNetCore.Mvc;
using Taller1IDWM.Src.Models;
using Taller1IDWM.Src.Repositories.Interfaces;

namespace Taller1IDWM.Src.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryRepository categoryRepository) : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

/// <summary>
/// Obtiene una lista con todas las categorias registradas
/// </summary>
/// <returns>la lista</returns>
    [HttpGet]
    public async Task<IResult> GetCategories(){
        var categories = await _categoryRepository.GetCategories();
        return TypedResults.Ok(categories);
    }
}