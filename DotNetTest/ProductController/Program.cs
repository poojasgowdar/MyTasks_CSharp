using Entities.Models;
using Interfaces.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Repositories.Repository;
using Services;
using Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("Defaultconnection")));

builder.Services.AddScoped<IRepository, ProductRepository>();
builder.Services.AddScoped<IService, ProductService>();
builder.Services.AddMemoryCache();
//builder.Services.AddScoped(typeof(IRepository<Product>), typeof(ProductRepository));

//builder.Services.AddScoped<IService, ProductService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//builder.Services.AddControllers(options =>
//{
//    options.Filters.Add<ValidateModelWithLoggingAttribute>();
//});


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Use(async (context, next) =>
{
    Console.WriteLine($"Incoming Request: {context.Request.Method} {context.Request.Path}");
    await next();
    Console.WriteLine($"Outgoing Response: {context.Response.StatusCode}");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();






