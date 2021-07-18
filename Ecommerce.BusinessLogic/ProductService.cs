using AutoMapper;
using Ecommerce.BusinessLogic.Interfaces;
using Ecommerce.Core;
using Ecommerce.Domain;
using Ecommerce.Domain.Interfaces;
using Shared.Infrastructure.Core;
using Shared.Infrastructure.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.BusinessLogic
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreatedProductDto> CreateAsync(ProductToCreateDto entity)
        {
            var product = _mapper.Map<Product>(entity);
            await _unitOfWork.Products.Create(product);
            _unitOfWork.Commit();
            return _mapper.Map<CreatedProductDto>(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Products.DeleteAsync(nameof(Constants.EntityNames.Product), id);
            _unitOfWork.Commit();
        }

        public async Task<ProductDto> ReadAsync(int id)
        {
            var product = await _unitOfWork.Products.ReadAsync(id);
            product.MustExist(nameof(Constants.EntityNames.Product), id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> ReadAsync()
        {
            var products = await _unitOfWork.Products.ReadAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> UpdateAsync(UpdateProductDto entity)
        {
            var product = _mapper.Map<Product>(entity);
            await _unitOfWork.Products.UpdateAsync(nameof(Constants.EntityNames.Product), product);
            _unitOfWork.Commit();
            return _mapper.Map<ProductDto>(product);
        }
    }
}
