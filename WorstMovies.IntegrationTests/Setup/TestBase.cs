using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorstMovies.Infrastructure.Data;
using WorstMovies.Infrastructure.Data.DTOs;
using WorstMovies.Infrastructure.Data.Services;

namespace WorstMovies.IntegrationTests.Setup;

[Collection("WebApplicationFactory")]
public abstract class TestBase: IAsyncLifetime
{
    public HttpClient Client { get; }
    public MovieDbContext Context { get; }
    public IServiceProvider Services { get; }
    
    public TestBase(WorstMoviesApplicationFactory worstMoviesApplicationFactory)
    {
        Client = worstMoviesApplicationFactory.CreateClient();
        Client.BaseAddress = new Uri("http://localhost:5202");
        Context = worstMoviesApplicationFactory.DatabaseContext;
        Services = worstMoviesApplicationFactory.Services;
    }

    public async Task InitializeAsync()
    {
        await Context.Database.EnsureCreatedAsync();
        Context.ChangeTracker.Clear();
    }

    public async Task DisposeAsync()
    {
        await Context.Database.EnsureDeletedAsync();
    }

    public async Task BuilderAndLoadCsvFileMoviesAsync(IEnumerable<MovieFromCsvDto> movies)
    {
        var databaseInitializer = Services.GetRequiredService<DatabaseInitializer>();
        var configuration = Services.GetRequiredService<IConfiguration>();
        var csvFilePath = configuration.GetValue<string>("CsvFilePath");
        
        var directoryPath = Path.GetDirectoryName(csvFilePath);
        if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        } 
        
        using var writer = new StreamWriter(csvFilePath);
        using var csvWriter = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
        });
        await csvWriter.WriteRecordsAsync(movies);
        await csvWriter.FlushAsync();
        
        await databaseInitializer.InitializeDatabaseAsync();
    }
}