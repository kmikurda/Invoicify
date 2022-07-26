using Application.Queries;
using MediatR;
using Microsoft.Extensions.Logging.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(typeof(GetAllUsersQuery));


var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Serilog config
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

builder.Host.UseSerilog();
//serilog config end

try
{
    Log.Information("asd");
    Log.Fatal("Fatal {asd}", 10);
}
catch (Exception e)
{
    Log.Fatal("Fatal error");
}
finally
{
    Log.CloseAndFlush();
}
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.UseSerilogRequestLogging();
app.Run();