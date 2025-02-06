using DataAccessLayer.Context;
using DataAccessLayer.Models;
using Interfaces.Interface;
using Microsoft.EntityFrameworkCore;
using PManagement.Mappings;
using PManagement.Repositories;
using Services.ProductService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("PManagement")
    ));


builder.Services.AddAutoMapper(typeof(CreateMapper));
builder.Services.AddScoped(typeof(IRepository<Product>), typeof(ProductRepository));

builder.Services.AddScoped<IService, ProductService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
