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
        modelBuilder.Entity<Category>()
            .HasMany(e => e.Products)
            .WithOne(e => e.Category)
            .HasForeignKey(e => e.CategoryId)
            .HasPrincipalKey(e => e.Id);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Orders)
            .WithOne(o => o.Product)
            .HasForeignKey(o => o.ProductId)
            .HasPrincipalKey(o => o.Id);

        modelBuilder.Entity<Order>().HasKey(o => o.Id);

        modelBuilder.Entity<Category>().HasData(
                       new Category { Id = 1, Name = "Elektronik", Description = "Elektronik kategorisindeki ürünler." },
                       new Category { Id = 2, Name = "Kitap", Description = "Kitap kategorisindeki ürünler." },
                       new Category { Id = 3, Name = "Müzik DVD", Description = "Müzik DVD kategorisindeki ürünler.Fs" }
            );

        modelBuilder.Entity<Product>().HasData(
                   new Product
                   {
                       Id = 1,
                       Name = "Sani Dual Monitor 1240",
                       CategoryId = 1,
                       InStock = true,
                       ListPrice = 12500.50M
                   },
                   new Product
                   {
                       Id = 2,
                       Name = "ElGi Ultra HD Monitor",
                       CategoryId = 1,
                       InStock = true,
                       ListPrice = 11000.50M
                   },
                   new Product
                   {
                       Id = 3,
                       Name = "WD HDD 2.5 Tb",
                       CategoryId = 1,
                       InStock = false,
                       ListPrice = 345.99M
                   },
                   new Product
                   {
                       Id = 4,
                       Name = "Programming OData Services",
                       CategoryId = 2,
                       InStock = true,
                       ListPrice = 54.50M
                   }
        );

        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, CustomerId = 1, Quantity = 5, ProductId = 1, OrderDate = DateTime.Now.AddDays(-1) },
            new Order { Id = 2, CustomerId = 2, Quantity = 3, ProductId = 1, OrderDate = DateTime.Now.AddDays(-2) },
            new Order { Id = 3, CustomerId = 3, Quantity = 10, ProductId = 1, OrderDate = DateTime.Now.AddDays(-5) }
        );

        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 4, CustomerId = 6, Quantity = 15, ProductId = 2, OrderDate = DateTime.Now.AddDays(-10) },
            new Order { Id = 5, CustomerId = 7, Quantity = 30, ProductId = 2, OrderDate = DateTime.Now.AddDays(-20) },
            new Order { Id = 6, CustomerId = 8, Quantity = 5, ProductId = 2, OrderDate = DateTime.Now.AddDays(-60) }
        );

        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 7, CustomerId = 9, Quantity = 40, ProductId = 3, OrderDate = DateTime.Now.AddDays(-90) }
        );

        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 8, CustomerId = 190, Quantity = 12, ProductId = 4, OrderDate = DateTime.Now.AddDays(-7) },
            new Order { Id = 9, CustomerId = 191, Quantity = 6, ProductId = 4, OrderDate = DateTime.Now.AddDays(-6) },
            new Order { Id = 10, CustomerId = 192, Quantity = 8, ProductId = 4, OrderDate = DateTime.Now.AddDays(-6) },
            new Order { Id = 11, CustomerId = 193, Quantity = 22, ProductId = 4, OrderDate = DateTime.Now.AddDays(-3) },
            new Order { Id = 12, CustomerId = 194, Quantity = 35, ProductId = 4, OrderDate = DateTime.Now.AddDays(-7) }
        );
    }
}