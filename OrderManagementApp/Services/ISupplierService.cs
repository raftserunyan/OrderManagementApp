using OrderManagementApp.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagementApp.UI.Services
{
    public interface ISupplierService
    {
        Task<List<SupplierModel>> GetAllSuppliersAsync();
        Task<SupplierModel> GetSupplierByIdAsync(int id);
        Task<SupplierModel> UpdateSupplierAsync(SupplierUpdateRequest request);
        Task<SupplierModel> CreateSupplierAsync(SupplierCreationRequest request);
        Task DeleteSupplierAsync(int id);
    }
}
