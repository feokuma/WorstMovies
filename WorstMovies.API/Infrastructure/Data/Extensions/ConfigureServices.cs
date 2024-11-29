using Microsoft.EntityFrameworkCore;
using WorstMovies.Infrastructure.Data.Repositories;

namespace WorstMovies.Infrastructure.Data.Extensions;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<MovieDbContext>(options => options.UseSqlite("Data Source=WorstMovies.db"));
        services.AddScoped<IMovieRepository, MovieRepository>();
        return services;
    }
}