using Infrastructure.Context;
using Infrastructure.Interfaces.Read;
using Infrastructure.Interfaces.Write;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Invoicify.Startups;

public class ServicesRegister
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        //DbContext
        services.AddDbContext<InvoicifyContext>(opts =>
            opts.UseSqlServer("Server=KMIKURDA\\SQLEXPRESS;Database=Invoicify;Trusted_Connection=True"));
        //Repositories
        services.AddScoped<IInvoiceReadRepository, InvoiceReadRepository>();
        services.AddScoped<IInvoiceWriteRepository, InvoiceWriteRepository>();
    }
}