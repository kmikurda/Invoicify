using Application.Queries;
using Invoicify.Startups;
using MediatR;
using Microsoft.Extensions.Logging.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(typeof(GetAllUsersQuery));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();



var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

ServicesRegister.RegisterServices(builder.Services,configuration);

// Serilog config
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

builder.Host.UseSerilog();
//serilog config end

try
{
    Log.Information("Program has been started");
}
catch (Exception e)
{
    Log.Fatal($"Fatal error: {e}");
}
finally
{
    Log.CloseAndFlush();
}
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.MapControllers();
app.UseStaticFiles();
app.Run();
