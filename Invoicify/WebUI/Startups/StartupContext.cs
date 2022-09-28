using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Invoicify.Startups;

public static class StartupContext
{
    public static void RegisterContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<InvoicifyContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("InvoicifyContext")));

    }
}