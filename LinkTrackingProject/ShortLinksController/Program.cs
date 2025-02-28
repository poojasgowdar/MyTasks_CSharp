using Entities.Entities;
using Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using Middleware.Middleware;
using Repositories.Repositories;
using Services;
using ShortLinksController.Controllers;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IShortLinkRepository, ShortLinkRepository>();
builder.Services.AddScoped<IClickLogRepository, ClickLogRepository>();
builder.Services.AddScoped<ShortLinkService>();
// Program.cs or Startup.cs
builder.Services.AddScoped<IClickLogRepository, ClickLogRepository>();
builder.Services.AddScoped<ClickLogService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LinkTrackingDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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
