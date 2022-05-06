using OrderManagementApp.Shared.Enums;

namespace OrderManagementApp.Models
{
    public class Supplier
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
