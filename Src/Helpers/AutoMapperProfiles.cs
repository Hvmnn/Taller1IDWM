using AutoMapper;
using Taller1IDWM.Src.DTOs.Account;
using Taller1IDWM.Src.DTOs.User;
using Taller1IDWM.Src.Models;

namespace courses_dotnet_api.Src.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<ProductDto, Product>();
        CreateMap<User, CredentialDto>();
        CreateMap<User, UserDto>();
    }
}