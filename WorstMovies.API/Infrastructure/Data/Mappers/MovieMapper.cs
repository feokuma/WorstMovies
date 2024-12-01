using WorstMovies.Domain;
using WorstMovies.Infrastructure.Data.DTOs;

namespace WorstMovies.Infrastructure.Data.Mappers;

public static class MovieMapper
{
    public static Movie ToMovie(this MovieFromCsvDto movieFromCsvDto)
    {
        return new Movie()
        {
            Year = movieFromCsvDto.Year,
            Title = movieFromCsvDto.Title,
            Producer = movieFromCsvDto.Producer,
            Studio = movieFromCsvDto.Studio,
            Winner = movieFromCsvDto.Winner,
        };
    }
}