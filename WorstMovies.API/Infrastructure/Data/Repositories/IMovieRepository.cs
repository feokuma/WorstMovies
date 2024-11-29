using WorstMovies.Domain;

namespace WorstMovies.Infrastructure.Data.Repositories;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<Movie?> GetByIdAsync(int id);
}