using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartStocker.Models;

namespace SmartStocker
{
    public class AppDbContext : DbContext
    {
        // TODO: verplaatsen van string
        static readonly string connectionString = "Server=localhost; User ID=root; Database=SmartStocker";

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connectionString);
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
