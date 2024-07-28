using BusinisseObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinisseObjects;

public class AppDbContext : DbContext
{
    private IConfiguration Configuration { get; }
    public AppDbContext()
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(GetConnectionString());
    }
    
    private string? GetConnectionString()
    {
        return Configuration.GetConnectionString("DefaultConnection");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Primary keys
        modelBuilder.Entity<Member>().HasKey(m => m.MemberId);
        modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
        modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
        modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
        modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.OrderId, od.ProductId });
        // Relationships
        modelBuilder.Entity<Product>()
            .HasOne<Category>(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);
        modelBuilder.Entity<OrderDetail>()
            .HasOne<Order>(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.OrderId);
        modelBuilder.Entity<OrderDetail>()
            .HasOne<Product>(od=> od.Product)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(od => od.ProductId);
        modelBuilder.Entity<Order>()
            .HasOne<Member>(o=> o.Member)
            .WithMany(m=> m.Orders)
            .HasForeignKey(o=> o.MemberId);
    }
}