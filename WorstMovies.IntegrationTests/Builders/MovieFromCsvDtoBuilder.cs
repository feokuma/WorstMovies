using AutoBogus;
using WorstMovies.Infrastructure.Data.DTOs;

namespace WorstMovies.IntegrationTests.Builders;

public class MovieFromCsvDtoBuilder: AutoFaker<MovieFromCsvDto>
{
    public MovieFromCsvDtoBuilder()
    {
        RuleFor(movie => movie.Title, faker => faker.Random.Words());
        RuleFor(movie => movie.Year, faker => faker.Random.Int(1980, 2024));
        RuleFor(movie => movie.Studio, faker => faker.Random.Words());
        RuleFor(movie => movie.Producer, faker => faker.Random.Word());
        RuleFor(movie => movie.Winner, () => string.Empty);
    }
}