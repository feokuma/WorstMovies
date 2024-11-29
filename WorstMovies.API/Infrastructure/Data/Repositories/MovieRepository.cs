using Microsoft.EntityFrameworkCore;
using WorstMovies.Domain;

namespace WorstMovies.Infrastructure.Data.Repositories;

public class MovieRepository: IMovieRepository
{
    private readonly MovieDbContext _context;
    
    public MovieRepository(MovieDbContext context)
    {
       _context = context;
    }
    
    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        return await _context.Movies.ToListAsync();
    }

    public async Task<Movie?> GetByIdAsync(int id)
    {
        return await _context.Movies.FindAsync(id);
    }
}