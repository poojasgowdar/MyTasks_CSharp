using Entities.Models;
using Filter.Filters;
using Interfaces.Interface;
using Microsoft.EntityFrameworkCore;
using Middleware.MiddleWares;
using Repository.Repositories;
using Services.ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepository, ProductRepository>();
builder.Services.AddScoped<IService, ProductService>();
builder.Services.AddMemoryCache();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));
builder.Services.AddLogging();
builder.Services.AddScoped<LogActionFilter>();
var app = builder.Build();

app.UseMiddleware<LoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
