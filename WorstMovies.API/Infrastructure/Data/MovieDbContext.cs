using Microsoft.EntityFrameworkCore;
using WorstMovies.Domain;

namespace WorstMovies.Infrastructure.Data;

public class MovieDbContext : DbContext 
{
    public DbSet<Movie> Movies { get; set; }
    
    public MovieDbContext(DbContextOptions<MovieDbContext> options):base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}