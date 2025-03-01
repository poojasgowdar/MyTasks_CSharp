using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MVC_New_Project.Helpers;
using MVC_New_Project.Interfaces;
using MVC_New_Project.Middleware;
using MVC_New_Project.Models;
using MVC_New_Project.Repository;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(ProductRepository<>));


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".SessionTrackingApp";
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.IsEssential = true;
});
//builder.Services.AddSwaggerGen(c =>   
//{
//    c.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
//    {
//        Description = "Enter your username and password to access the API",
//        Name = "Authorization",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.Http,
//        Scheme = "Basic"
//    });
//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "Basic"
//                }
//            },
//            new string[] { }
//        }
//    });
//});

builder.Services.AddAuthentication("BasicAuthentication")
        .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseMiddleware<LoggingMiddleware>();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "login",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
