using System.Text.Json;
using WorstMovies.Infrastructure.Data.Extensions;
using WorstMovies.Infrastructure.Data.Repositories;
using WorstMovies.Infrastructure.Data.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOpenApi()
    .AddInfrastructureServices();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var databaseInitializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
    databaseInitializer.InitializeDatabase();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", async (IMovieRepository movieRepository) =>
{
    var movies = await movieRepository.GetAllAsync();
    return JsonSerializer.Serialize(movies);
}).WithName("Get All Movies");

app.Run();

public partial class Program { }