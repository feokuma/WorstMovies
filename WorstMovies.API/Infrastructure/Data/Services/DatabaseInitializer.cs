using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using WorstMovies.Infrastructure.Data.DTOs;
using WorstMovies.Infrastructure.Data.Mappers;

namespace WorstMovies.Infrastructure.Data.Services;

public class DatabaseInitializer
{
    private readonly MovieDbContext _movieDbContext;
    
    public DatabaseInitializer(MovieDbContext context)
    {
        _movieDbContext = context; 
    }

    public void InitializeDatabase()
    {
        _movieDbContext.Database.EnsureDeleted();
        _movieDbContext.Database.EnsureCreated();
        
        SeedDataFromCSV("Infrastructure/movielist.csv");
    }

    private void SeedDataFromCSV(string csvFilePath)
    {
        using var reader = new StreamReader(csvFilePath);
        using var csvMovies = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
            HasHeaderRecord = true
        });

        var movies = csvMovies.GetRecords<MovieFromCsvDto>().Select(m => m.ToMovie());

        _movieDbContext.Movies.AddRange(movies);
        _movieDbContext.SaveChanges();
    }
}