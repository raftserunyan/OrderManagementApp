using OrderManagementApp.Data.Interfaces;
using OrderManagementApp.Data.Models;
using OrderManagementApp.Data.Repositories.Common;

namespace OrderManagementApp.Data.Repositories
{
    internal class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(OrderManagementAppDbContext context) : base(context)
        {
        }
    }
}
