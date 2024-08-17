//using Microsoft.EntityFrameworkCore;

//namespace XuongMay_BE.Model
//{
//    public class XuongMayContext:DbContext
//    {
//        public XuongMayContext(DbContextOptions options):base(options)
//        {

//        }
//        public DbSet<Customer> Customers { get; set; } 
//        public DbSet<Category> Categories { get; set; }
//        public DbSet<Order> Orders { get; set; }
//        public DbSet<OrderDetail>OrderDetels { get; set; }
//        public DbSet<Product> Products { get; set; }
//        public DbSet<ProductionLine>ProductionLines { get; set; }
//        public DbSet<Role> Roles { get; set; }
//        public DbSet<Task> Tasks { get; set; }
//        public User User { get; set; }
//        public User_Role User_Roles { get; set; }
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Order>()
//                .Property(o => o.Total_amount)
//                .HasConversion<decimal>(); // Chuyển đổi giá trị thành decimal
//        }
//    }
//}
