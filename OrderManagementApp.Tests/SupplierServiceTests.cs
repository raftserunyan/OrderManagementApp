using System;
using Xunit;
using Moq;
using OrderManagementApp.Business.Interfaces;
using OrderManagementApp.Data.Interfaces;
using AutoMapper;
using OrderManagementApp.Business.Services;
using System.Linq.Expressions;
using OrderManagementApp.Models;
using OrderManagementApp.Shared.CustomExceptions;
using System.Threading.Tasks;

namespace OrderManagementApp.Tests
{
    public class SupplierServiceTests
    {
        private readonly ISupplierService _supplierService;

        private readonly Mock<IUnitOfWork> _unitOfWorkMoq = new Mock<IUnitOfWork>();
        private readonly Mock<IMapper> _mapperMoq = new Mock<IMapper>();

        public SupplierServiceTests()
        {
            _supplierService = new SupplierService(_unitOfWorkMoq.Object, _mapperMoq.Object);
        }

        [Fact]
        public async Task GetByIdAsync_WhenIdIsInvalid_ThrowsNotFoundException()
        {
            _unitOfWorkMoq.Setup(x => x.Suppliers.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Supplier, bool>>>())).Throws(new NotFoundException());

            await Assert.ThrowsAsync<NotFoundException>(async () => await _supplierService.GetByIdAsync(11));
        }
    }
}
