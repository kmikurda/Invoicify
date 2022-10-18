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
                    .SetBasePath(AppContext.BaseDirectory + "../../../../WebUI")
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: false)
                    .AddEnvironmentVariables()
                    .Build()
                    .GetConnectionString(ConnectionStringName);

           // connectionString =
              //  "Server=tcp:kmikurda.database.windows.net,1433;Initial Catalog=Invoicify;Persist Security Info=False;User ID=kmikurda;Password=Wielka09$$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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