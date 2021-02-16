using AutoMapper;
using Ecommerce.Business.Dto;
using Ecommerce.Business.Dto.Mappings;
using Ecommerce.Domain.DAL;
using Ecommerce.Domain.Model;
using Ecommerce.Domain.Repositories;
using Ecommerce.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Ecommerce.Business.Services.IntegrationTest
{
    public class ProductServiceTest
    {
        private readonly DatabaseContext Context;
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

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
    }
}
