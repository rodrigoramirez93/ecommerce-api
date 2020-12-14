using AutoMapper;
using Ecommerce.Business.Dto;
using Ecommerce.Business.Dto.Validators;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core;
using Ecommerce.Domain.Model;
using Ecommerce.Domain.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Business.Services
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

        public ProductDto Update(ProductDto entity)
        {
            var product = _mapper.Map<Product>(entity);
            _unitOfWork.Products.Update(product);
            _unitOfWork.Commit();
            return _mapper.Map<ProductDto>(product);
        }
    }
}
