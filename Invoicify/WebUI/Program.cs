using System.Reflection;
using Application.Queries;
using Invoicify.Startups;
using MediatR;
using Microsoft.Extensions.Logging.Configuration;
using Serilog;
using ILogger = Serilog.ILogger;

var environment = Environment.GetEnvironmentVariable("MCS_ENVIRONMENT") ?? "Development";


var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Configuration
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{environment}.json", true, true)
    .AddEnvironmentVariables();
StartupCQRS.RegisterServices(builder.Services);
StartupAutofac.RegisterServices(builder.Services);
StartupContext.RegisterContext(builder.Services, builder.Configuration);
StartupAuth.RegisterServices(builder.Services);
// Serilog config
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog();
builder.Host.UseSerilog();
//serilog config end


var app = builder.Build();
app.UseSwagger();
app.MapGet("/", () => "Hello World!");
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestWebApi"); });
app.UseSerilogRequestLogging();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.UseStaticFiles();
app.UseCors("EnableCORS");
app.UseSerilogRequestLogging();
try
{
    Log.Information("Program has been started");
    app.Run();
}
catch (Exception e)
{
    Log.Fatal($"Fatal error: {e}");
}
finally
{
    Log.CloseAndFlush();
}
