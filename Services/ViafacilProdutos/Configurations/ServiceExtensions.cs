using Microsoft.EntityFrameworkCore;
using ViafacilProdutos.Data;
using ViafacilProdutos.Interfaces;
using ViafacilProdutos.Services;

namespace ViafacilProdutos.Cofigurations;

public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection service)
    {
        service.AddScoped<IProductService, ProductService>();
    }

    public static void ConfigureDb(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<ProductsContext>(option =>
        {
            option.UseSqlServer(
                configuration.GetConnectionString("DatabaseConnection"),
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure
                (
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null
                )
            );
        });
    }
}