using EfClass.DataAccess;
using EfClass.DataAccess.Repositories;
using EfClass.Managers;
using EfClass.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();



builder.Services.AddTransient<IBookRepository, BooksRepository>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));

builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IBookManager, BookManager>();
builder.Services.AddTransient<IUsersManager, UsersManager>();


//Db
builder.Services.AddDbContext<BookDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("Defaultconnection")));

//add automapper
builder.Services.AddAutoMapper(typeof(Program));

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
