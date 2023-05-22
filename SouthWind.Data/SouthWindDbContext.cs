using Microsoft.EntityFrameworkCore;
using SouthWind.Data.Entity;

namespace SouthWind.Data;

public class SouthWindDbContext
    : DbContext, IApplicationDbContext
{
    public SouthWindDbContext() { }
    public SouthWindDbContext(DbContextOptions<SouthWindDbContext> options) : base(options) { }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryID);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Orders)
            .WithOne(o => o.Product)
            .HasForeignKey(o => o.ProductID);
    }
}