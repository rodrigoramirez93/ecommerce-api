using AutoMapper;
using Ecommerce.BusinessLogic;
using Ecommerce.BusinessLogic.Interfaces;
using Ecommerce.BusinessLogic.Mappings;
using Ecommerce.Core;
using Ecommerce.Domain;
using Ecommerce.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Ecommerce.Business.Services.IntegrationTest
{
    public class ProductServiceTest
    {
        private readonly DatabaseContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggedUserService _loggedUserService;
        private readonly int _invalidId = 1;

        public ProductServiceTest()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
              .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
              .Options;

            _context = new DatabaseContext(options);

            var _mapperConfig = new MapperConfiguration(cfg => cfg.AddMaps(typeof(ProductProfile).Assembly));
            _mapper = new Mapper(_mapperConfig);
            _unitOfWork = new UnitOfWork(_context);
            _loggedUserService = new LoggedUserService();
        }

        #region positive_tests
        [Fact]
        public async Task GivenProductService_WhenAddingValidProduct_ShouldAddWithoutErrors()
        {
            //arrange
            var product = new ProductToCreateDto() { Name = "Product", Description = "Some Product", Price = 10, Stock = 1 };
            var service = new ProductService(_unitOfWork, _mapper, _loggedUserService);
            var beforeCount = await _context.Products.CountAsync();

            //act
            var createdProduct = await service.CreateAsync(product);
            var afterCount = await _context.Products.CountAsync();

            //assert
            Assert.NotEqual(beforeCount, afterCount);
            Assert.NotNull(createdProduct);
            Assert.NotNull(await _context.Products.SingleOrDefaultAsync());
        }

        [Fact]
        public async Task GivenProductService_WhenDeletingValidProduct_ShouldDeleteWithoutError()
        {
            //arrange
            var product = new Product() { Name = "test", Description = "test" };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            var service = new ProductService(_unitOfWork, _mapper, _loggedUserService);
            var beforeCount = await _context.Products.CountAsync();

            //act
            await service.DeleteAsync(product.Id);
            await _context.SaveChangesAsync();
            var afterCount = await _context.Products.CountAsync();

            //assert
            Assert.NotEqual(beforeCount, afterCount);
            Assert.Equal(0, afterCount);

        } 

        [Fact]
        public async Task GivenProductService_WhenReadingValidProductById_ShouldReadItWithoutErrors()
        {
            //arrange
            var product = new Product() { Name = "test", Description = "test" };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            var service = new ProductService(_unitOfWork, _mapper, _loggedUserService);
            
            //act
            var readProduct = await service.ReadAsync(product.Id);
            
            //Assert
            Assert.NotNull(readProduct);
            Assert.Equal(product.Name, readProduct.Name);
            Assert.Equal(product.Description, readProduct.Description);
        }

        [Fact]
        public async Task GivenProductService_WhenReadingValidProduct_ShouldReadItWithoutErrors()
        {
            //arrange
            var firstProduct = new Product() { Name = "test", Description = "test" };
            var secondProduct = new Product() { Name = "test 2", Description = "test 2" };
            _context.Products.AddRange(firstProduct, secondProduct);
            await _context.SaveChangesAsync();
            var service = new ProductService(_unitOfWork, _mapper, _loggedUserService);

            //act
            var products = await service.ReadAsync();
            var productCount = products.Count();

            //Assert
            Assert.True(productCount > 0);
            Assert.Equal(2, productCount);
            Assert.NotEqual(0, productCount);
        }

        [Fact]
        public async Task GivenProductService_WhenUpdatingAValidProduct_ShouldUpdateWithoutErrors()
        {
            //arrange
            var product = new Product() { Name = "test", Description = "test" };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            var service = new ProductService(_unitOfWork, _mapper, _loggedUserService);

            //act
            var newProduct = await service.UpdateAsync(new UpdateProductDto() { Id = product.Id, Name = "new name", Description = "new description" });

            //assert
            Assert.Equal("new name", newProduct.Name);
            Assert.Equal("new description", newProduct.Description);
        }
        #endregion

        #region negative_test
        
        [Fact]
        public async Task GivenProductService_WhenDeletingAProductThatDoesntExist_ShouldThrowError()
        {
            //act
            var service = new ProductService(_unitOfWork, _mapper, _loggedUserService);

            //assert
            var exception = await Assert.ThrowsAsync<AppException>(async () => await service.DeleteAsync(_invalidId));

            Assert.IsType<AppException>(exception);
            Assert.Equal(exception.Message, $"Product with Id {_invalidId} does not exist. Please contact your administrator.");
        }

        [Fact]
        public async Task GivenProductService_WhenReadingAProductThatDoesntExist_ShouldThrowError()
        {
            //act
            var service = new ProductService(_unitOfWork, _mapper, _loggedUserService);

            //assert
            var exception = await Assert.ThrowsAsync<AppException>(async () => await service.ReadAsync(_invalidId));

            Assert.IsType<AppException>(exception);
            Assert.Equal(exception.Message, $"Product with Id {_invalidId} does not exist. Please contact your administrator.");
        }

        [Fact]
        public async Task GivenProductService_WhenUpdatingAProductThatDoesntExist_ShouldThrowError()
        {
            //act
            var service = new ProductService(_unitOfWork, _mapper, _loggedUserService);

            //assert
            var exception = await Assert.ThrowsAsync<AppException>(async () => await service.UpdateAsync(new UpdateProductDto() { Id = 1 }));

            Assert.IsType<AppException>(exception);
            Assert.Equal(exception.Message, $"Product does not exist. Please contact your administrator.");
        }
        #endregion
    }
}
