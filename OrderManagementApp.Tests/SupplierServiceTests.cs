using System;
using Xunit;
using Moq;
using OrderManagementApp.Business.Interfaces;
using OrderManagementApp.Data.Interfaces;
using AutoMapper;
using OrderManagementApp.Business.Services;

namespace OrderManagementApp.Tests
{
    public class SupplierServiceTests
    {
        private readonly ISupplierService _supplierService;

        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();

        public SupplierServiceTests()
        {
            _supplierService = new SupplierService(_unitOfWork.Object, _mapper.Object);
        }

        [Fact]
        public void GetByIdAsync_WhenIdIsInvalid_ThrowsNotFoundException()
        {
            //// Arrange
            //_unitOfWork.Setup(x => x.Suppliers.GetFirstOrDefaultAsync())

            //// Act
            //var productPages = await _productService
            //    .SearchAsync(pageInfo, new ProductSearch() { SearchQuery = "-1" }, true);

            //// Assert
            //Assert.Equal(0, productPages.Page.TotalItems);
            //Assert.IsType<PagedData<ProductDisplayEntity>>(productPages);
        }
    }
}
