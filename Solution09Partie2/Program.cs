using Microsoft.EntityFrameworkCore;
using Solution09Partie2.Models;
using Solution09Partie2.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ShoppingDbContext") ?? throw new InvalidOperationException("Connection string 'ShoppingDbContext' not found.");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//ajouter un service de base de données
builder.Services.AddDbContext<ShoppingDbContext>(
    options =>
     options.UseMySql("name=ConnectionStrings:AlwaysDataConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.11.14-mariadb"))
            .UseLazyLoadingProxies()
     );

//Ajouter un servcie CustomerRep injectable
builder.Services.AddScoped<ICustomersRepository, CustomersRepositoryImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
