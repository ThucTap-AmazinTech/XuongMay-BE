using Microsoft.EntityFrameworkCore;
using XuongMay_BE.Models;

namespace XuongMay_BE.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductionLine> ProductionLines { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User_Role> User_Roles { get; set; }
    }
}
