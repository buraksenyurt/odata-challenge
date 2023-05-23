using Microsoft.EntityFrameworkCore;

namespace SouthWind.Data;
public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}