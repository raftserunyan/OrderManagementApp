using Microsoft.EntityFrameworkCore;
using OrderManagementApp.Data.Models;

namespace OrderManagementApp.Data
{
    internal class OrderManagementAppDbContext : DbContext
    {
        public OrderManagementAppDbContext(DbContextOptions<OrderManagementAppDbContext> options) : base(options)
        {
        }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}
