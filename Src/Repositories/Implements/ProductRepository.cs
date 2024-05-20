using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Taller1IDWM.Src.Data;
using Taller1IDWM.Src.DTOs.Product;
using Taller1IDWM.Src.Models;

namespace Taller1IDWM.Src.Repositories.Interfaces;

public class ProductRepository(DataContext dataContext, IMapper mapper) : IProductRepository
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    public async Task AddProduct(AddEditProductDto addProductDto)
    {
        addProductDto.Name = addProductDto.Name.ToLower();
        Product product = _mapper.Map<Product>(addProductDto);
        var category = await _dataContext.Categories.FindAsync(product.CategoryId);
        if (category != null){
            product.Category = category;
        }
        await _dataContext.Products.AddAsync(product);
    }

    public async Task<bool> DeleteProduct(int id)
    {
        var existingProduct = await _dataContext.Products.FindAsync(id);
        if (existingProduct == null)
        {
            return false;
        }

        _dataContext.Remove(existingProduct);
        return true;
    }

    public async Task<bool> EditProduct(int id, AddEditProductDto editProductDto)
    {
        var existingProduct = await _dataContext.Products.FindAsync(id);
        if (existingProduct == null)
        {
            return false;
        }

        existingProduct.Name = editProductDto.Name ?? existingProduct.Name;
        existingProduct.Name = existingProduct.Name.ToLower();
        
        existingProduct.Price = editProductDto.Price;
        existingProduct.Stock = editProductDto.Stock;
        existingProduct.ImageUrl = editProductDto.ImageUrl ?? existingProduct.ImageUrl;
        existingProduct.CategoryId = editProductDto.CategoryId;

        _dataContext.Entry(existingProduct).State = EntityState.Modified;

        return true;
    }

    public async Task<IEnumerable<GetProductDto>> GetProducts()
    {
        var products = await _dataContext.Products.ProjectTo<GetProductDto>(_mapper.ConfigurationProvider).ToListAsync();
        return products;
    }

    public async Task<bool> ProductExistsById(int id)
    {
        return await _dataContext.Products.AnyAsync(x => x.Id == id);
    }

    public async Task<bool> ProductExistsByNameAndType(AddEditProductDto productDto)
    {
        return await _dataContext.Products.AnyAsync(x => x.Name == productDto.Name.ToLower()
                                                    && x.CategoryId == productDto.CategoryId);
    }

    public async Task<bool> reduceStock(int id, int stockToReduce)
    {
        var existingProduct = await _dataContext.Products.FindAsync(id);
        if (existingProduct == null)
        {
            return false;
        }
        if (existingProduct.Stock < stockToReduce){
            return false;
        }
        existingProduct.Stock -= stockToReduce;

        _dataContext.Entry(existingProduct).State = EntityState.Modified;

        return true;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return 0 < await _dataContext.SaveChangesAsync();
    }
}