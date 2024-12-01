using Microsoft.EntityFrameworkCore;
using WorstMovies.Infrastructure.Data.Repositories;
using WorstMovies.Infrastructure.Data.Services;

namespace WorstMovies.Infrastructure.Data.Extensions;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<MovieDbContext>(options => options.UseSqlite("Data Source=WorstMovies.db"));
        services.AddTransient<DatabaseInitializer>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        return services;
    }
}