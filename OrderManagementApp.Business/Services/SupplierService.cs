using AutoMapper;
using OrderManagementApp.Business.Interfaces;
using OrderManagementApp.Data.Interfaces;
using OrderManagementApp.Models;
using OrderManagementApp.Shared.CustomExceptions;
using OrderManagementApp.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagementApp.Business.Services
{
    public class SupplierService : ISupplierService
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

        public async Task DeleteSupplierAsync(int id)
        {
            var supplier = await _uow.Suppliers.GetFirstOrDefaultAsync(x => x.Id == id);
            ThrowBadDataExceptionIfNull(supplier, id);

            supplier.IsDeleted = true;
            await _uow.SaveChangesAsync();
        }

        public async Task<IEnumerable<SupplierModel>> GetAllSuppliersAsync()
        {
            var suppliers = await _uow.Suppliers.GetWhereAsync(x => !x.IsDeleted);

            return _mapper.Map<IEnumerable<SupplierModel>>(suppliers);
        }

        public async Task<SupplierModel> GetByIdAsync(int id)
        {
            var supplier = await _uow.Suppliers.GetFirstOrDefaultAsync(x => x.Id == id);
            ThrowNotFoundExceptionIfNull(supplier, id);

            return _mapper.Map<SupplierModel>(supplier);
        }

        public async Task<SupplierModel> UpdateSupplierAsync(SupplierUpdateRequest request)
        {
            var supplier = await _uow.Suppliers.GetFirstOrDefaultAsync(x => x.Id == request.Id);
            ThrowBadDataExceptionIfNull(supplier, request.Id);

            _mapper.Map(request, supplier);
            await _uow.SaveChangesAsync();

            return _mapper.Map<SupplierModel>(supplier);
        }

        // Private methods
        private void ThrowBadDataExceptionIfNull(object entity, int id)
        {
            if (entity == null)
            {
                throw new BadDataException($"Invalid Id {id}. No such object was found");
            }
        }
        private void ThrowNotFoundExceptionIfNull(object entity, int id)
        {
            if (entity == null)
            {
                throw new NotFoundException($"Object with id {id} was not found");
            }
        }
    }
}
