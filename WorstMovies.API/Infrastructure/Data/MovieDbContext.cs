using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WorstMovies.Domain;

namespace WorstMovies.Infrastructure.Data;

public class MovieDbContext : DbContext 
{
    private readonly string _connectionString;
    public DbSet<Movie> Movies { get; set; }

    public MovieDbContext(DbContextOptions<MovieDbContext> options, IConfiguration configuration) : base(options)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection"); 
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_connectionString);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}