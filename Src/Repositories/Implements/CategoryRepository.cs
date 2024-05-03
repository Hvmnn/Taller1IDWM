using Taller1IDWM.Src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Taller1IDWM.Src.Data;
using Taller1IDWM.Src.Models;

namespace Taller1IDWM.Src.Repositories.Implements;

public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _context;

    public CategoryRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Category?> GetCategoryById(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        return category;
    }

    public async Task<Category?> GetCategoryByName(string name)
    {
        var category = await _context.Categories.Where(r => r.Name == name).FirstOrDefaultAsync();
        return category;
    }
}