using OrderManagementApp.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagementApp.Business.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierModel>> GetAllSuppliersAsync();
        Task<SupplierModel> GetByIdAsync(int id);
        Task DeleteSupplierAsync(int id);
        Task<SupplierModel> CreateSupplierAsync(SupplierCreationRequest request);
        Task<SupplierModel> UpdateSupplierAsync(int id, SupplierUpdateRequest request);
    }
}
