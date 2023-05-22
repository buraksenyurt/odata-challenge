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

        modelBuilder.Entity<Category>().HasData(
                       new Category { Id = 1, Name = "Elektronik" },
                       new Category { Id = 2, Name = "Kitap" },
                       new Category { Id = 3, Name = "Müzik DVD" }
            );

        modelBuilder.Entity<Product>().HasData(
                   new Product
                   {
                       Id = 1,
                       Name = "Sani Dual Monitor 1240",
                       CategoryId = 1,
                       InStock = true,
                       ListPrice = 12500.50M,
                       Orders = new List<Order>
                       {
                            new Order{CustomerId=1,Quantity=5,ProductId=1,OrderDate=DateTime.Now.AddDays(-1)},
                            new Order{CustomerId=2,Quantity=3,ProductId=1,OrderDate=DateTime.Now.AddDays(-2)},
                            new Order{CustomerId=3,Quantity=10,ProductId=1,OrderDate=DateTime.Now.AddDays(-5)}
                       }
                   },
                   new Product
                   {
                       Id = 2,
                       Name = "ElGi Ultra HD Monitor",
                       CategoryId = 1,
                       InStock = true,
                       ListPrice = 11000.50M,
                       Orders = new List<Order>
                       {
                            new Order{CustomerId=6,Quantity=15,ProductId=2,OrderDate=DateTime.Now.AddDays(-10)},
                            new Order{CustomerId=7,Quantity=30,ProductId=2,OrderDate=DateTime.Now.AddDays(-20)},
                            new Order{CustomerId=8,Quantity=5,ProductId=2,OrderDate=DateTime.Now.AddDays(-60)}
                       }
                   }
        );
    }
}