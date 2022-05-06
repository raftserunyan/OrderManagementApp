using OrderManagementApp.Data;
using OrderManagementApp.Data.Interfaces;
using OrderManagementApp.Data.Repositories;
using System.Threading.Tasks;

namespace OrderManagementApp.Repositories.Data
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly OrderManagementAppDbContext _context;
        private ISupplierRepository _supplierRepo;

        public UnitOfWork(OrderManagementAppDbContext context)
        {
            _context = context;
        }

        public ISupplierRepository Suppliers 
        {
            get { return _supplierRepo ??= _supplierRepo = new SupplierRepository(_context); }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
