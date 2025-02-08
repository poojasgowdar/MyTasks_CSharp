using Interfaces.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Middlewares.Middleware;
using Models.Entities;
using Repositories.Repository;
using Services.Service;
using StudentController.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRepository, StudentRepository>();
builder.Services.AddScoped<IService, StudentService>();
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
