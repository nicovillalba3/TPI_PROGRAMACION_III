using Application.Services;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json.Serialization;
using Infrastructure.Data;
using Domain.Interfaces;
using Infraestructure.Repositories;
using Infraestructure;
using Microsoft.Data.Sqlite;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Configura el cach� en memoria
builder.Services.AddDistributedMemoryCache(); // Agrega el cach� en memoria

// Configura la sesi�n
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Configura el tiempo de expiraci�n de la sesi�n
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DBConecctionString"),
        b => b.MigrationsAssembly("Web")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configurar el pipeline de middleware HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseSession(); // Aseg�rate de que esto est� aqu�
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
