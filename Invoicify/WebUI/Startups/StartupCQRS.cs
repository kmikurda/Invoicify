namespace Invoicify.Startups;

public static class StartupCQRS
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<ICommand>
    }
}