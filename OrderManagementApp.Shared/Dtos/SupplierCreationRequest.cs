using OrderManagementApp.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementApp.Shared.Dtos
{
    public class SupplierCreationRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public State State { get; set; }
    }
}
