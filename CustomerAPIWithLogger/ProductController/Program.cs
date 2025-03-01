using Entities.Models;
using Interface.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repositories.Repository;
using Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IRepository, ProductRepository>();
builder.Services.AddTransient<IService, ProductService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));
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
