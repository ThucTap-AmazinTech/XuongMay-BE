using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMay_BE.Contract.Repositories.Entities;

namespace XuongMay_BE.Repositories.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductionLine> ProductionLines { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Contract.Repositories.Entities.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User_Roles> User_Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chuyển đổi giá trị thành decimal
            modelBuilder.Entity<Order>()
                .Property(o => o.Total_amount)
                .HasConversion<decimal>();
        }
    }
}
