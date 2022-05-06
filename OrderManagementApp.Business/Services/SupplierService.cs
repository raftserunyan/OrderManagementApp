using AutoMapper;
using OrderManagementApp.Business.Interfaces;
using OrderManagementApp.Business.Services.Common;
using OrderManagementApp.Data.Interfaces;
using OrderManagementApp.Models;
using OrderManagementApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementApp.Business.Services
{
    internal class SupplierService : BaseService, ISupplierService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public SupplierService(IUnitOfWork uow,
                               IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<SupplierModel> CreateSupplierAsync(SupplierCreationRequest request)
        {
            var supplier = _mapper.Map<Supplier>(request);

            await _uow.Suppliers.AddAsync(supplier);
            await _uow.SaveChangesAsync();

            return _mapper.Map<SupplierModel>(supplier);
        }

        public async Task<IEnumerable<SupplierModel>> GetAllSuppliersAsync()
        {
            var suppliers = await _uow.Suppliers.GetAllAsync();

            return _mapper.Map<IEnumerable<SupplierModel>>(suppliers);
        }

        public async Task<SupplierModel> GetByIdAsync(int id)
        {
            var supplier = await _uow.Suppliers.GetFirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<SupplierModel>(supplier);
        }

        public async Task<SupplierModel> UpdateSupplierAsync(SupplierUpdateRequest request)
        {
            var supplier = await _uow.Suppliers.GetFirstOrDefaultAsync(x => x.Id == request.Id);
            

            await _uow.SaveChangesAsync();
            return _mapper.Map<SupplierModel>(supplier);
        }
    }
}
