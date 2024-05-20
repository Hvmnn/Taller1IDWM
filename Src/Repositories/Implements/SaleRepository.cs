using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Taller1IDWM.Src.Data;
using Taller1IDWM.Src.DTOs.Product;
using Taller1IDWM.Src.Models;
using Taller1IDWM.Src.Repositories.Interfaces;

namespace Taller1IDWM.Src.Repositories.Implements;

public class SaleRepository(DataContext dataContext, IMapper mapper) : ISaleRepository
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    public async Task<IEnumerable<GetSaleDto>> GetSales()
    {
        var sales = await _dataContext.Sales.ProjectTo<GetSaleDto>(_mapper.ConfigurationProvider).ToListAsync();
        return sales;
    }

    public async Task<IEnumerable<GetUserSaleDto>> GetSales(int userId)
    {
        var sales = await _dataContext.Sales.Where(s => s.UserId == userId).OrderBy( s => s.SaleDate).
                    ProjectTo<GetUserSaleDto>(_mapper.ConfigurationProvider).ToListAsync();
        return sales;
    }

    public async Task<GetUserSaleDto> MakeSale(MakeSaleDto saleDto)
    {
        Sale sale = _mapper.Map<Sale>(saleDto);
        var user = await _dataContext.Users.FindAsync(sale.UserId);
        if (user != null)
        {
            sale.User = user;
        }
        var product = await _dataContext.Products.FindAsync(sale.ProductId);
        if (product != null)
        {
            var category = await _dataContext.Categories.FindAsync(product.CategoryId);
            if (category!=null){
                product.Category = category;
            }
            sale.Product = product;
            sale.Total = product.Price*saleDto.SaleStock;
        }
        sale.SaleDate = DateTime.Now;
        await _dataContext.Sales.AddAsync(sale);
        await _dataContext.SaveChangesAsync();

        return _mapper.Map<GetUserSaleDto>(sale);
        
    }

    public async Task<bool> SaveChangesAsync()
    {
        return 0 < await _dataContext.SaveChangesAsync();
    }
}