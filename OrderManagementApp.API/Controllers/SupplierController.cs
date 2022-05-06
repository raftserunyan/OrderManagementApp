using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementApp.Business.Interfaces;
using OrderManagementApp.Shared.Dtos;
using System.Threading.Tasks;

namespace OrderManagementApp.API.Controllers
{
    [Route("api/Suppliers")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();

            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllSuppliers(int id)
        {
            var supplier = await _supplierService.GetByIdAsync(id);

            return Ok(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> GetAllSuppliers(SupplierCreationRequest request)
        {
            var supplier = await _supplierService.CreateSupplierAsync(request);

            return Ok(supplier);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(SupplierUpdateRequest request)
        {
            var supplier = await _supplierService.UpdateSupplierAsync(request);

            return Ok(supplier);
        }
    }
}
