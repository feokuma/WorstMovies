using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
}

app.UseHttpsRedirection();

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
}).WithName("Get producers with longest Winner intervals");

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
}).WithName("Get producers with smallest Winner intervals");

app.Run();

public partial class Program { }