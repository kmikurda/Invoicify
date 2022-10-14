using Common.CQRS.Commands;
using Common.CQRS.Events;
using Common.CQRS.Queries;
using MediatR;

namespace Invoicify.Startups;

public static class StartupCQRS
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IMediator, Mediator>();
        services.AddTransient<ServiceFactory>(p => p.GetService);
        
        services.AddScoped<ICommandBus, CommandBus>();
        services.AddScoped<IQueryBus, QueryBus>();
        services.AddScoped<IEventBus, EventBus>();
    }
}