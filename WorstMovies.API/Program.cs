using Scalar.AspNetCore;
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
    databaseInitializer.InitializeDatabaseAsync();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapGet("/movies", async (IMovieRepository movieRepository) =>
{
    var movies = await movieRepository.GetAllAsync();
    var response = new
    {
        type = "list",
        description = "Get all movies",
        data = movies
    };
    return Results.Ok(response);
}).WithSummary("Get all movies");

app.MapGet("/movies/{id:int}", async (IMovieRepository movieRepository, int id) =>
{
    var movie = await movieRepository.GetByIdAsync(id);
    var response = new
    {
        type = "item",
        description = "Get movie by id",
        data = movie
    };
    return Results.Ok(response);
}).WithSummary("Get movie by id");

app.MapGet("/winnerproducer/interval/max", async (IMovieRepository movieRepository) =>
{
    var moviesWithLongestWinnerIntervals = await movieRepository.GetProducersWithLongestWinnerIntervals();
    var response = new
    {
        type = "max",
        description = "Producers with longest winner intervals",
        data = moviesWithLongestWinnerIntervals,
    };
    return Results.Ok(response);
}).WithSummary("Get producers with longest Winner intervals");

app.MapGet("/winnerproducer/interval/min", async (IMovieRepository movieRepository) =>
{
    var moviesWithSmallesttWinnerIntervals = await movieRepository.GetProducersWithSmallestWinnerIntervals();
    var response = new
    {
        type = "min",
        description = "Producers with smallest winner intervals",
        data = moviesWithSmallesttWinnerIntervals,
    };
    return Results.Ok(response);
}).WithSummary("Get producers with smallest Winner intervals");

app.Run();

public partial class Program { }