using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SouthWind.Data;
public static class DependencyInjection
{
    public static IServiceCollection AddDataContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SouthWindDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("SouthWindConStr"))
            );

        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<SouthWindDbContext>());
        return services;
    }
}