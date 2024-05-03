using AutoMapper;
using Taller1IDWM.Src.Models;

namespace courses_dotnet_api.Src.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<ProductDto, Product>();
    }
}