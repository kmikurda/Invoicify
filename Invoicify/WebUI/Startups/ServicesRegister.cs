using Infrastructure.Interfaces.Read;
using Infrastructure.Repositories;

namespace Invoicify.Startups;

public class ServicesRegister
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        //Repositories
        services.AddScoped<IInvoiceReadRepository, InvoiceReadRepository>();
    }
}