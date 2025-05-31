using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartStocker.Abscrations;
using SmartStocker.Models;
using SmartStocker.Models.Entities;

namespace SmartStocker
{
    public class AppDbContext(IOptions<Connections> conn) : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(conn.Value.DefaultConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.OrderedBy)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.OrderedById);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId);
        }
    }
}
