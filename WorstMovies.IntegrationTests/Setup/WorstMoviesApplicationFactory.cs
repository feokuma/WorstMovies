using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorstMovies.Infrastructure.Data;

namespace WorstMovies.IntegrationTests.Setup;

public class WorstMoviesApplicationFactory: WebApplicationFactory<Program>, IDisposable
{
    public MovieDbContext DatabaseContext;
    public IServiceScope ServiceScope;
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        builder.ConfigureAppConfiguration(config =>
        {
            var integrationAppSettings = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Testing.json")
                .Build();
            config.AddConfiguration(integrationAppSettings);
        });

        builder.ConfigureServices(services =>
        {
            ServiceScope = services.BuildServiceProvider().CreateScope();
            DatabaseContext = ServiceScope.ServiceProvider.GetRequiredService<MovieDbContext>();
        });
    }

    public void Dispose()
    {
        DatabaseContext.Database.EnsureDeleted();
        DatabaseContext.Dispose();
        ServiceScope.Dispose();
    }
}