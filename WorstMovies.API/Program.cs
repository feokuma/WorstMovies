using WorstMovies.Infrastructure.Data.Extensions;
using WorstMovies.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOpenApi()
    .AddInfrastructureServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", async (IMovieRepository movieRepository) =>
{
    var movies = await movieRepository.GetAllAsync();
    return "It Works!";
}).WithName("Get All Movies");

app.Run();