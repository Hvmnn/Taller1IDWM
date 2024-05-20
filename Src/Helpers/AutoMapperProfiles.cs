using AutoMapper;
using Taller1IDWM.Src.DTOs.Account;
using Taller1IDWM.Src.DTOs.Product;
using Taller1IDWM.Src.DTOs.User;
using Taller1IDWM.Src.DTOs.Account;
using Taller1IDWM.Src.DTOs.User;
using Taller1IDWM.Src.Models;

namespace courses_dotnet_api.Src.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<AddEditProductDto, Product>();
        CreateMap<User, CredentialDto>();
        CreateMap<User, UserDto>();
        CreateMap<User, GetUserDto>();
        CreateMap<Product, GetProductDto>();
        CreateMap<Product, GetProductSaleDto>();
        CreateMap<MakeSaleDto, Sale>();
        CreateMap<Sale, GetSaleDto>();
        CreateMap<Sale, GetUserSaleDto>();
        CreateMap<ProductDto, Product>();
        CreateMap<User, CredentialDto>();
        CreateMap<User, UserDto>();
    }
}