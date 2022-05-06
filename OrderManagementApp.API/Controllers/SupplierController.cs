using Microsoft.AspNetCore.Mvc;
using OrderManagementApp.Business.Interfaces;
using OrderManagementApp.Shared.Dtos;
using System.Collections.Generic;
using System.Net;
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
        [ProducesResponseType(typeof(IEnumerable<SupplierModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();

            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SupplierModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetSupplierById(int id)
        {
            var supplier = await _supplierService.GetByIdAsync(id);

            return Ok(supplier);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SupplierModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateNewSupplier([FromBody] SupplierCreationRequest request)
        {
            var supplier = await _supplierService.CreateSupplierAsync(request);

            return Ok(supplier);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SupplierModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateSupplier(int id, [FromBody] SupplierUpdateRequest request)
        {
            var supplier = await _supplierService.UpdateSupplierAsync(request);

            return Ok(supplier);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            await _supplierService.DeleteSupplierAsync(id);

            return NoContent();
        }
    }
}
