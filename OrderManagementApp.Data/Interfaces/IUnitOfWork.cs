using System;
using System.Threading.Tasks;

namespace OrderManagementApp.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISupplierRepository Suppliers { get; }

        Task SaveChangesAsync();
    }
}
