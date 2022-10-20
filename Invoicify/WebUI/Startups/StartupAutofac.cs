using Application.Commands;
using Application.Dto;
using Application.Interfaces.Read;
using Application.Queries.Invoices;
using Application.QueryHandlers;
using Application.QueryHandlers.Invoices;
using Domain.Entities;
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
       services.AddScoped<IRequestHandler<GetAllInvoicesQuery, List<Invoice>>, GetAllInvoicesQueryHandler>();
       services.AddScoped<IRequestHandler<GetUnassignedInvoicesQuery, List<Invoice>>, GetUnassignedInvoicesQueryHandler>();
       services.AddScoped<IRequestHandler<GetInvoiceByOwnerQuery, List<Invoice>>, GetInvoiceByOwnerQueryHandler>();
       services.AddScoped<IRequestHandler<GetInvoicesToAuthorizationByUserQuery, List<Invoice>>, GetInvoicesToAuthorizationByUserQueryHandler>();
       services.AddScoped<IRequestHandler<GetWaitingForVerificationInvoicesQuery, List<Invoice>>, GetWaitingForVerificationInvoicesQueryHandler>();
    }
}