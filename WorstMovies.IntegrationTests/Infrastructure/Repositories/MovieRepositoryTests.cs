using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using WorstMovies.Infrastructure.Data.Repositories;
using WorstMovies.IntegrationTests.Builders;
using WorstMovies.IntegrationTests.Setup;

namespace WorstMovies.IntegrationTests.Infrastructure.Repositories;

public class MovieRepositoryTests: TestBase
{
    private readonly IMovieRepository _movieRepository;

    public MovieRepositoryTests(WorstMoviesApplicationFactory factory) : base(factory)
    {
        _movieRepository = factory.ServiceScope.ServiceProvider.GetRequiredService<IMovieRepository>();
    }

    [Fact]
    public async Task Should_GetAllMoviesFromDatabase()
    {
        var movies = new MovieFromCsvDtoBuilder().Generate(2);
        await BuilderAndLoadCsvFileMoviesAsync(movies);
        
        var moviesFromDatabase = await _movieRepository.GetAllAsync();
        
        moviesFromDatabase.Should().BeEquivalentTo(movies);
    }
}