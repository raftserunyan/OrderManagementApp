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

        /// <summary>
        /// Retrieves all the suppliers which are in the DataBase
        /// </summary>
        /// <returns>Http 200 with the list of suppliers found or an empty array if no suppliers were found</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SupplierModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();

            return Ok(suppliers);
        }

        /// <summary>
        /// Searches for a supplier with the specified ID
        /// </summary>
        /// <param name="id">The Id of the supplier you want to get</param>
        /// <returns>Http 200 with the requested supplier or Http 404 if no supplier was found with the given ID</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SupplierModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetSupplierById(int id)
        {
            var supplier = await _supplierService.GetByIdAsync(id);

            return Ok(supplier);
        }

        /// <summary>
        /// Creates a new supplier with the given properties, assigns it an ID and returns back
        /// </summary>
        /// <param name="request">A supplierCreationRequest instance which will be used to create the new supplier</param>
        /// <returns>Http 200 with the new created Supplier or Http 400 if the data provided was invalid</returns>
        [HttpPost]
        [ProducesResponseType(typeof(SupplierModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateNewSupplier([FromBody] SupplierCreationRequest request)
        {
            var supplier = await _supplierService.CreateSupplierAsync(request);

            return Ok(supplier);
        }

        /// <summary>
        /// Updates the existing supplier with the given new values
        /// </summary>
        /// <param name="id">The ID of the existing supplier which's to be updated</param>
        /// <param name="request">The request with the new values</param>
        /// <returns>Http 200 with the updated Supplier or Http 400 if the data provided was invalid</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SupplierModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateSupplier(int id, [FromBody] SupplierUpdateRequest request)
        {
            var supplier = await _supplierService.UpdateSupplierAsync(id, request);

            return Ok(supplier);
        }

        /// <summary>
        /// Deletes the supplier with the given ID
        /// </summary>
        /// <param name="id">The ID of the supplier which's to be deleted</param>
        /// <returns>HTTP 204 if the supplier was deleted successfully or HTTP 400 if no supplier was found with the given ID</returns>
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
