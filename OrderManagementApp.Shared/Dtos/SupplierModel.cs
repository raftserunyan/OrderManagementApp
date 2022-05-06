using OrderManagementApp.Shared.Enums;

namespace OrderManagementApp.Shared.Dtos
{
    public class SupplierModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public State State { get; set; }
    }
}
