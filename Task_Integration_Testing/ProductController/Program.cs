using DataAccessLayer.Entities;
using Manager.ProductManager;
using Microsoft.EntityFrameworkCore;
using ProductController.Controllers;
using Repositories.ProductRepositories;
using Service.ProductServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var env = builder.Environment.EnvironmentName;

    if (env != "Testing")
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<IProductService, ProductService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MyMappingProfile));
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
public partial class Program
{

}
