using Taller1IDWM.Src.DTOs.Product;
using Taller1IDWM.Src.Models;

namespace Taller1IDWM.Src.Repositories.Interfaces;
public interface ISaleRepository
{
    Task<IEnumerable<GetSaleDto>> GetSales();

    Task<IEnumerable<GetUserSaleDto>> GetSales(int userId);

    Task<GetUserSaleDto> MakeSale(MakeSaleDto saleDto);

    Task<bool> SaveChangesAsync();
}