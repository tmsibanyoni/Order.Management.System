using Microsoft.EntityFrameworkCore;
using Order.Management.Repository.Models;

namespace Order.Management.Repository.Helpers
{
    public class ApplicationDbContextHelper : DbContext
    {
        public ApplicationDbContextHelper(DbContextOptions<ApplicationDbContextHelper> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerOrder>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<OrdersDetail>()
            .HasKey(b => b.Id);
        }

        public DbSet<CustomerOrder> CustomersOrders { get; set; }
        public DbSet<OrdersDetail> OrdersDetail { get; set; }
    }
}
