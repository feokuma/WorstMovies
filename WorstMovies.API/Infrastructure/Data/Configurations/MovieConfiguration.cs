using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorstMovies.Domain;

namespace WorstMovies.Infrastructure.Data.Configurations;

public class MovieConfiguration: IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Year).IsRequired();
        builder.Property<string>(m => m.Title).IsRequired();
        builder.Property(m => m.Producer).IsRequired();
        builder.Property(m => m.Studio);
        builder.Property(m => m.Winner).IsRequired();
    }
}