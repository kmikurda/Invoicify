using Infrastructure.Context;
using Infrastructure.Interfaces.Read;
using Infrastructure.Interfaces.Write;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Invoicify.Startups;

public static class StartupAutofac
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        //Repositories
        services.AddScoped<IInvoiceReadRepository, InvoiceReadRepository>();
        services.AddScoped<IInvoiceWriteRepository, InvoiceWriteRepository>();
        services.AddScoped<IAuthorizationWriteRepository, AuthorizationWriteRepository>();
    }
}