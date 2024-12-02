using AutoBogus;
using Bogus;
using WorstMovies.Infrastructure.Data.DTOs;

namespace WorstMovies.IntegrationTests.Builders;

public class MovieFromCsvDtoBuilder: AutoFaker<MovieFromCsvDto>
{ 
    private string[] producers = ["John Doe", "Jane Smith", "Alice Johnson", "Bob Brown", "Charlie White"];
    public MovieFromCsvDtoBuilder()
    {
        RuleFor(movie => movie.Title, faker => faker.Random.Words());
        RuleFor(movie => movie.Year, faker => faker.Random.Int(1980, 2024));
        RuleFor(movie => movie.Studio, faker => faker.Random.Words());
        RuleFor(movie => movie.Producer, faker => faker.PickRandom(producers));
        RuleFor(movie => movie.Winner, () => string.Empty);
    }

    public MovieFromCsvDtoBuilder FromYear(int year)
    {
        RuleFor(movie => movie.Year, year);
        return this;
    }
    
    public MovieFromCsvDtoBuilder AsWinner()
    {
        RuleFor(movie => movie.Winner, "yes");
        return this;
    }
}