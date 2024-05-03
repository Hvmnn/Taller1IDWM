using Taller1IDWM.Src.DTOs;
using Taller1IDWM.Src.Models;

namespace Taller1IDWM.Src.Repositories.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<ProductDto>> GetProducts();

    Task<bool> EditProduct(int id, ProductDto editProductDto);

    Task<bool> DeleteProduct(int id);

    Task AddProduct(ProductDto addProductDto);

    Task<bool> ProductExistsByName(string name);

    Task<bool> SaveChangesAsync();
}