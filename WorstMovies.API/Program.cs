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

app.MapGet("/getwinnerproducers", async (IMovieRepository movieRepository) =>
{
    var moviesWithSmallestWinnerIntervals = await movieRepository.GetProducersWithSmallestWinnerIntervals();
    var moviesWithLongestWinnerIntervals = await movieRepository.GetProducersWithLongestWinnerIntervals();
    var result = new
    {
        min = moviesWithSmallestWinnerIntervals,
        max = moviesWithLongestWinnerIntervals,
    };
    return JsonSerializer.Serialize(result);
}).WithName("Get Producers with Smallest and Longest Winner Intervals");

app.Run();

public partial class Program { }