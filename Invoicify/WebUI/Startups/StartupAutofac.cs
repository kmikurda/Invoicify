using Application.Commands;
using Application.Dto;
using Application.Interfaces.Read;
using Application.QueryHandlers;
using Infrastructure.Context;
using Infrastructure.Interfaces.Read;
using Infrastructure.Interfaces.Write;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Invoicify.Startups;

public static class StartupAutofac
{
    public static void RegisterServices(IServiceCollection services)
    {
        //Repositories
        services.AddScoped<IInvoiceReadRepository, InvoiceReadRepository>();
        services.AddScoped<IInvoiceWriteRepository, InvoiceWriteRepository>();
        services.AddScoped<IUserReadRepository, UserReadRepository>();
        //Commands
        
        
        //Queries
       services.AddScoped<IRequestHandler<LoginQuery, AuthToken>, LoginQueryHandler>();
    }
}