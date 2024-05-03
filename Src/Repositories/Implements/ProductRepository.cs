using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Taller1IDWM.Src.Data;
using Taller1IDWM.Src.DTOs;
using Taller1IDWM.Src.Models;

namespace Taller1IDWM.Src.Repositories.Interfaces;

public class ProductRepository(DataContext dataContext, IMapper mapper) : IProductRepository
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    public async Task AddProduct(ProductDto addProductDto)
    {
        addProductDto.Name = addProductDto.Name.ToLower();
        Product product = _mapper.Map<Product>(addProductDto);
        await _dataContext.Products.AddAsync(product);
    }

    public async Task<bool> DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> EditProduct(int id, ProductDto editProductDto)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ProductExistsByName(string name)
    {
        name = name.ToLower();
        return await _dataContext.Products.AnyAsync(x => x.Name == name);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return 0 < await _dataContext.SaveChangesAsync();
    }
}