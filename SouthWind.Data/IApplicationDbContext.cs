using Microsoft.EntityFrameworkCore;

namespace SouthWind.Data;
public interface IApplicationDbContext
{
    // public DbSet<Musician> Musicians { get; set; }
    // public DbSet<Album> Albums { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}