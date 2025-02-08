using Interfaces.Interface;
using Microsoft.EntityFrameworkCore;
using Middleware.Middlewares;
using Models.Entities;
using ProductController.Controllers;
using Repository.Repositories;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRepository, ProductRepository>();
builder.Services.AddScoped<IService, ProductService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("Defaultconnection")));
builder.Services.AddAutoMapper(typeof(MyMappingProfile));
var app = builder.Build();
app.UseMiddleware<LoggingMiddleware>();

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
