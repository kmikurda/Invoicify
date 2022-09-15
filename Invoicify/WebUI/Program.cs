using Application.Queries;
using Invoicify.Startups;
using MediatR;
using Microsoft.Extensions.Logging.Configuration;
using Serilog;
using ILogger = Serilog.ILogger;

var environment = Environment.GetEnvironmentVariable("MCS_ENVIRONMENT") ?? "Development";


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(typeof(GetAllUsersQuery));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Configuration
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{environment}.json", true, true)
    .AddEnvironmentVariables();

ServicesRegister.RegisterServices(builder.Services,builder.Configuration);
// Serilog config
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
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
app.MapGet("/", () => "Hello World!");
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestWebApi"); });
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.MapControllers();
app.UseStaticFiles();
app.Run();
