using CsvHelper.Configuration.Attributes;

namespace WorstMovies.Infrastructure.Data.DTOs;

public class MovieFromCsvDto
{
    [Name("year")]
    public int Year { get; set; } 
    [Name("title")]
    public string Title { get; set; }
    [Name("studios")]
    public string Studio { get; set; }
    [Name("producers")]
    public string Producer { get; set; }
    [Name("winner")]
    public string Winner { get; set; }
}