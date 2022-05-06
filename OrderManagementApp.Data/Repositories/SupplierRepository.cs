using OrderManagementApp.Data.Interfaces;
using OrderManagementApp.Data.Repositories.Common;
using OrderManagementApp.Models;

namespace OrderManagementApp.Data.Repositories
{
    internal class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(OrderManagementAppDbContext context) : base(context)
        {
        }
    }
}
