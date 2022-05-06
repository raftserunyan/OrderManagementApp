using Microsoft.EntityFrameworkCore;
using OrderManagementApp.Models;

namespace OrderManagementApp.Data
{
    public class OrderManagementAppDbContext : DbContext
    {
        public OrderManagementAppDbContext(DbContextOptions<OrderManagementAppDbContext> options) : base(options)
        {
        }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}
