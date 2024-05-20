using Taller1IDWM.Src.DTOs.Product;

namespace Taller1IDWM.Src.Repositories.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<GetProductDto>> GetProducts();

    Task<bool> EditProduct(int id, AddEditProductDto editProductDto);

    Task<bool> DeleteProduct(int id);

    Task AddProduct(AddEditProductDto addProductDto);

    Task<bool> ProductExistsByNameAndType(AddEditProductDto addProductDto);

    Task<bool> ProductExistsById(int id);

    Task<bool> reduceStock(int id, int stockToReduce);

    Task<bool> SaveChangesAsync();
}