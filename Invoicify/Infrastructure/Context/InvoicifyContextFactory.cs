using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context;

public class InvoicifyContextFactory : IDesignTimeDbContextFactory<InvoicifyContext>
{
    private const string EnvironmentVariableName = "INVOICIFY_ENVIRONMENT";
    private const string ConnectionStringName = "InvoicifyContext";

    public InvoicifyContext CreateDbContext(string[] args)
    {
        
        var optionsBuilder = new DbContextOptionsBuilder<InvoicifyContext>();

        if (optionsBuilder.IsConfigured)
            return new InvoicifyContext(optionsBuilder.Options);

        var environmentName = Environment.GetEnvironmentVariable(EnvironmentVariableName) ?? "Development";
        Console.WriteLine(environmentName);
        string? connectionString;
        try
        {
            connectionString =
                new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory + "../../WebUI")
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: false)
                    .AddEnvironmentVariables()
                    .Build()
                    .GetConnectionString(ConnectionStringName);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }

        Console.WriteLine(ConnectionStringName);
        Console.WriteLine(connectionString);
        optionsBuilder.UseSqlServer(connectionString);

        return new InvoicifyContext(optionsBuilder.Options);
    }
}