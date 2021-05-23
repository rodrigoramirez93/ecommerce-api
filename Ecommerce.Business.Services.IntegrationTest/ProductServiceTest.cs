using AutoMapper;
using Ecommerce.BusinessLogic;
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
        private readonly DatabaseContext Context;
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;
        private readonly int invalidId = 1;

        public ProductServiceTest()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
              .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
              .Options;

            Context = new DatabaseContext(options);

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddMaps(typeof(ProductProfile).Assembly));
            Mapper = new Mapper(mapperConfig);
            UnitOfWork = new UnitOfWork(Context);

        }

        #region positive_tests
        [Fact]
        public async Task GivenProductService_WhenAddingValidProduct_ShouldAddWithoutErrors()
        {
            //arrange
            var product = new ProductToCreateDto() { Name = "Product", Description = "Some Product", Price = 10, Stock = 1 };
            var service = new ProductService(UnitOfWork, Mapper);
            var beforeCount = await Context.Products.CountAsync();

            //act
            var createdProduct = await service.CreateAsync(product);
            var afterCount = await Context.Products.CountAsync();

            //assert
            Assert.NotEqual(beforeCount, afterCount);
            Assert.NotNull(createdProduct);
            Assert.NotNull(await Context.Products.SingleOrDefaultAsync());
        }

        [Fact]
        public async Task GivenProductService_WhenDeletingValidProduct_ShouldDeleteWithoutError()
        {
            //arrange
            var product = new Product() { Name = "test", Description = "test" };
            Context.Products.Add(product);
            await Context.SaveChangesAsync();
            var service = new ProductService(UnitOfWork, Mapper);
            var beforeCount = await Context.Products.CountAsync();

            //act
            await service.DeleteAsync(product.Id);
            await Context.SaveChangesAsync();
            var afterCount = await Context.Products.CountAsync();

            //assert
            Assert.NotEqual(beforeCount, afterCount);
            Assert.Equal(0, afterCount);

        } 

        [Fact]
        public async Task GivenProductService_WhenReadingValidProductById_ShouldReadItWithoutErrors()
        {
            //arrange
            var product = new Product() { Name = "test", Description = "test" };
            Context.Products.Add(product);
            await Context.SaveChangesAsync();
            var service = new ProductService(UnitOfWork, Mapper);
            
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
            Context.Products.AddRange(firstProduct, secondProduct);
            await Context.SaveChangesAsync();
            var service = new ProductService(UnitOfWork, Mapper);

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
            Context.Products.Add(product);
            await Context.SaveChangesAsync();
            var service = new ProductService(UnitOfWork, Mapper);

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
            var service = new ProductService(UnitOfWork, Mapper);

            //assert
            var exception = await Assert.ThrowsAsync<AppException>(async () => await service.DeleteAsync(invalidId));

            Assert.IsType<AppException>(exception);
            Assert.Equal(exception.Message, $"Product with Id {invalidId} does not exist. Please contact your administrator.");
        }

        [Fact]
        public async Task GivenProductService_WhenReadingAProductThatDoesntExist_ShouldThrowError()
        {
            //act
            var service = new ProductService(UnitOfWork, Mapper);

            //assert
            var exception = await Assert.ThrowsAsync<AppException>(async () => await service.ReadAsync(invalidId));

            Assert.IsType<AppException>(exception);
            Assert.Equal(exception.Message, $"Product with Id {invalidId} does not exist. Please contact your administrator.");
        }

        [Fact]
        public async Task GivenProductService_WhenUpdatingAProductThatDoesntExist_ShouldThrowError()
        {
            //act
            var service = new ProductService(UnitOfWork, Mapper);

            //assert
            var exception = await Assert.ThrowsAsync<AppException>(async () => await service.UpdateAsync(new UpdateProductDto() { Id = 1 }));

            Assert.IsType<AppException>(exception);
            Assert.Equal(exception.Message, $"Product does not exist. Please contact your administrator.");
        }
        #endregion


    }
}
