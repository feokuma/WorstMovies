using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using WorstMovies.Infrastructure.Data.DTOs;
using WorstMovies.Infrastructure.Data.Mappers;

namespace WorstMovies.Infrastructure.Data.Services;

public class DatabaseInitializer
{
    private readonly MovieDbContext _movieDbContext;
    private readonly string _csvFilePath;
    
    public DatabaseInitializer(MovieDbContext context, IConfiguration configuration)
    {
        _movieDbContext = context; 
        _csvFilePath = configuration.GetValue<string>("CsvFilePath");
    }

    public async Task InitializeDatabaseAsync()
    {
        await _movieDbContext.Database.EnsureDeletedAsync();
        _movieDbContext.ChangeTracker.Clear();
        await _movieDbContext.Database.EnsureCreatedAsync();
        
        SeedDataFromCSV();
    }

    private void SeedDataFromCSV()
    {
        if (!File.Exists(_csvFilePath))
            return;
        
        using var reader = new StreamReader(_csvFilePath);
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