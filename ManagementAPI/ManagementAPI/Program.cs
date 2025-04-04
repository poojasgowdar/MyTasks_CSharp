using DataAccess;
using DataAccess.Models;
using Interface.Interfaces;
//using ManagementAPI.Mappings;
using ManagementAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Service;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    //sqlOptions => sqlOptions.MigrationsAssembly("DataAccess")
    ));


//builder.Services.AddAutoMapper(typeof(CreateMapper));
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
