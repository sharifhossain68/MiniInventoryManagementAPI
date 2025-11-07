using Microsoft.EntityFrameworkCore;
using MiniInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MiniInventory.Domain.Entities.Order;

namespace MiniInventory.Infrastructure.Data
{
    public class MiniInventoryDbContext : DbContext
    {
      
        public MiniInventoryDbContext(DbContextOptions<MiniInventoryDbContext> options) : base(options)
        {

        }


        public DbSet<Product> Products  =>Set<Product>();
        public DbSet<Order>  Orders  =>Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Set primary key using Fluent API
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);
            modelBuilder.Entity<Product>(p =>
            {
                p.Property(obj => obj.Name)
                      .HasMaxLength(300);  // same as [MaxLength(250)]
            });
            modelBuilder.Entity<Order>()
               .HasKey(o => o.OrderId);
            modelBuilder.Entity<Order>(o =>
            {
                o.Property(obj => obj.CustomerName)
                      .HasMaxLength(250);  // same as [MaxLength(250)]
            });

        }
    }
}
