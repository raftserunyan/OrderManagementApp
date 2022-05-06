using AutoMapper;
using OrderManagementApp.Models;
using OrderManagementApp.Shared.Dtos;

namespace OrderManagementApp.API.MapperProfiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierModel>();
            CreateMap<SupplierCreationRequest, Supplier>();
            CreateMap<SupplierUpdateRequest, Supplier>();
        }
    }
}
