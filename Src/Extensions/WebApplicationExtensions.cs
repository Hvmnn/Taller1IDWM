using Taller1IDWM.Src.Data;
using Microsoft.EntityFrameworkCore;

namespace Taller1IDWM.Src.Extensions;

public static class WebApplicationExtensions
{
    public static void ConfigureApp(this WebApplication app)
    {
        app.MapControllers();
        app.UseAuthentication();
        app.UseAuthorization();

        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<DataContext>();
            context.Database.Migrate();
            DataSeeder.Initialize(services);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<WebApplication>>();
            logger.LogError(ex, "An error occurred during migration");
        }
    }
}