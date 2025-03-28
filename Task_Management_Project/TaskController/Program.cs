using Manager.Managers;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Repositories.Repository;
using Service.Services;
using TaskController.Controllers;

var builder = WebApplication.CreateBuilder(args);
bool isTesting = builder.Environment.IsEnvironment("Testing");
if (isTesting)
{
    builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("DefaultConnection")));
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TestDb"));
}
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskManager, TaskManager>();
builder.Services.AddScoped<ITaskService, TaskService>();

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
