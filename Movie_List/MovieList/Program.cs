using Interface.Interfaces;
using Services.ServiceLayer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register Swagger/OpenAPI generator service.
builder.Services.AddSwaggerGen(c =>
{
    // Configure Swagger to use OpenAPI 3.0
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Movie API",
        Version = "v1",
        Description = "A simple API to filter movies",
    });

    // If you have EnumSchemaFilter or other custom filters
    // c.SchemaFilter<EnumSchemaFilter>();
});

builder.Services.AddScoped<IMovieService, MovieService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Set the Swagger version here
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
