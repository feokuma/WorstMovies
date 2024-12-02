using Bogus;
using WorstMovies.Infrastructure.Data.DTOs;
using WorstMovies.IntegrationTests.Builders;
using WorstMovies.IntegrationTests.Setup;
using FluentAssertions;

namespace WorstMovies.IntegrationTests.Endpoints;

public class GetWinnerProducers: TestBase
{
    public GetWinnerProducers(WorstMoviesApplicationFactory factory) : base(factory) { }

    [Fact]
    public async Task Should_ReturnWinnersWithSmallerAndLongestInterval()
    {
        var movies = new List<MovieFromCsvDto>();
        movies.AddRange(GenerateProducerMovies());
        await BuilderAndLoadCsvFileMoviesAsync(movies);
        string expectedJson = "{\"min\":[{\"Producer\":\"Bob Brown\",\"PreviewsWin\":2014,\"FollowingWin\":2019,\"Interval\":5},{\"Producer\":\"John Doe\",\"PreviewsWin\":2000,\"FollowingWin\":2006,\"Interval\":6}],\"max\":[{\"Producer\":\"Jane Smith\",\"PreviewsWin\":2001,\"FollowingWin\":2016,\"Interval\":15},{\"Producer\":\"Alice Johnson\",\"PreviewsWin\":2002,\"FollowingWin\":2017,\"Interval\":15}]}";
        
        var responseMessage = await Client.GetAsync("/getwinnerproducers");

        var response = await responseMessage.Content.ReadAsStringAsync();
        response.Should().BeEquivalentTo(expectedJson);
    }

    private List<MovieFromCsvDto> GenerateProducerMovies()
    {
        Randomizer.Seed = new Random(12345);
        var internalYears = 20;
        var startYear = 2000;
        var moviesByYear = 5;
        var endYear = startYear + internalYears - 1;

        var builder = new MovieFromCsvDtoBuilder();
        var movies = new List<MovieFromCsvDto>();

        for (var year = startYear; year <= endYear; year++)
        {
            var moviesFromYear = builder
                .FromYear(year)
                .Generate(moviesByYear);
            moviesFromYear.First().Winner = "yes";
            movies.AddRange(moviesFromYear);
        }
        
        return movies;
    }
}