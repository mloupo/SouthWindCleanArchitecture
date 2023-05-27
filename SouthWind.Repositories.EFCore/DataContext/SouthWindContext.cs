using Microsoft.EntityFrameworkCore;
using SouthWind.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWind.Repositories.EFCore.DataContext
{
    public class SouthWindContext :DbContext
    {
        public SouthWindContext(DbContextOptions<SouthWindContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> Details { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(c => c.Id).HasMaxLength(5).IsFixedLength();
            modelBuilder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<Order>().Property(o => o.CustomerId).IsRequired().HasMaxLength(5).IsFixedLength();
            modelBuilder.Entity<Order>().Property(o => o.ShipAddress).IsRequired().HasMaxLength(60);
            modelBuilder.Entity<Order>().Property(o => o.ShipCity).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Order>().Property(o => o.ShipCountry).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Order>().Property(o => o.ShipPostalCode).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.OrderId, od.ProductId });
            modelBuilder.Entity<Order>().HasOne<Customer>().WithMany().HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<OrderDetail>().HasOne<Product>().WithMany().HasForeignKey(od => od.ProductId);
            
            
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Chay" },
                new Product { Id = 2, Name = "Chey" },
                new Product { Id = 3, Name = "Choy" },
                new Product { Id = 4, Name = "Chuy" }
                );

            modelBuilder.Entity<Customer>().HasData(
               new Customer { Id = "ALFKI", Name = "Alfred F." },
               new Customer { Id = "ANATR", Name = "Ana Trujillo" },
               new Customer { Id = "ANTON", Name = "Antonio Orozco" },
               new Customer { Id = "DONOR", Name = "Tobias Moreno" }
               );


        }
    }
}
