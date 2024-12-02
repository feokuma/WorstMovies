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

    public async Task<IEnumerable<dynamic>> GetProducersWithSmallestWinnerIntervals()
    {
        return await _context.Movies
            .Where(m => m.Winner == "yes")
            .GroupBy(m => m.Producer)
            .Where(g => g.Count() >= 2)
            .Select(g => new
            {
                Producer = g.Key,
                PreviewsWin = g.Min(m => m.Year),
                FollowingWin = g.Max(m => m.Year),
                Interval = g.Max(m => m.Year) - g.Min(m => m.Year),
            })
            .OrderBy(r => r.Interval)
            .Take(2)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<dynamic>> GetProducersWithLongestWinnerIntervals()
    {
        return await _context.Movies
            .Where(m => m.Winner == "yes")
            .GroupBy(m => m.Producer)
            .Where(g => g.Count() >= 2)
            .Select(g => new
            {
                Producer = g.Key,
                PreviewsWin = g.Min(m => m.Year),
                FollowingWin = g.Max(m => m.Year),
                Interval = g.Max(m => m.Year) - g.Min(m => m.Year),
            })
            .OrderByDescending(r => r.Interval)
            .Take(2)
            .ToListAsync();
    }
}