using Microsoft.EntityFrameworkCore;
using Taller1IDWM.Src.Data;
using Taller1IDWM.Src.Repositories.Implements;
using Taller1IDWM.Src.Repositories.Interfaces;
using Taller1IDWM.Src.Services;

namespace Taller1IDWM.Src.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}