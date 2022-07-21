using Application.Queries;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(typeof(GetAllUsersQuery));



var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();