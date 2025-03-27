using Microsoft.EntityFrameworkCore;
using ViafacilReceipts.Data;
using ViafacilReceipts.Interfaces;
using ViafacilReceipts.Services;

namespace ViafacilReceipts.Cofigurations;

public static class ServiceExtensions
{
    public static void AddServicesAndServices(this IServiceCollection service)
    {
        service.AddScoped<IReceiptService, ReceiptService>();
    }

    public static void ConfigureDb(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<ReceiptsContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("DatabaseConnection"));
        });
    }
}