using Taller1IDWM.Src.Models;

namespace Taller1IDWM.Src.Repositories.Interfaces;
public interface ICategoryRepository
{
    Task<Category?> GetCategoryById(int id);

    Task<Category?> GetCategoryByName(string name);

    Task<IEnumerable<Category>> GetCategories();
}