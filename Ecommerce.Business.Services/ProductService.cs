using AutoMapper;
using Ecommerce.Business.Dto;
using Ecommerce.Business.Dto.Validators;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core;
using Ecommerce.Domain.Model;
using Ecommerce.Domain.Repositories.Interfaces;
using System.Collections.Generic;

namespace Ecommerce.Business.Services
{
    public class ProductServiceDto : IServiceDto<ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDtoValidator<ProductDtoValidator, ProductDto> _dtoValidator;
        private readonly IDtoValidator<ProductFilterDtoValidator, ProductFilterDto> _searchDtoValidator;
        private readonly IFilterBuilder _filterBuilder;
        public ProductServiceDto(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IDtoValidator<ProductDtoValidator, ProductDto> dtoValidator,
            IDtoValidator<ProductFilterDtoValidator, ProductFilterDto> searchDtoValidator,
            IFilterBuilder filterBuilder)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dtoValidator = dtoValidator;
            _searchDtoValidator = searchDtoValidator;
            _filterBuilder = filterBuilder;
        }

        public int Create(ProductDto entity)
        {
            _dtoValidator.Validate(entity, RuleSets.Create);
            var product = _mapper.Map<Product>(entity);
            _unitOfWork.Products.Create(product);
            _unitOfWork.Commit();
            return product.Id;
        }

        public void Delete(int id)
        {
            _unitOfWork.Products.Delete(id);
            _unitOfWork.Commit();
        }

        public ProductDto Read(int id)
        {
            var product = _unitOfWork.Products.Read(id);
            return _mapper.Map<ProductDto>(product);
        }

        public IEnumerable<ProductDto> Read(ProductFilterDto productFilterDto)
        {
            _searchDtoValidator.Validate(productFilterDto, RuleSets.Search);
            var filterConditions = _filterBuilder.Build(productFilterDto);
            var products = _unitOfWork.Products.Read(filterConditions);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public IEnumerable<ProductDto> Read()
        {
            var products = _unitOfWork.Products.Read();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public ProductDto Update(ProductDto entity)
        {
            _dtoValidator.Validate(entity, RuleSets.Update);
            var product = _mapper.Map<Product>(entity);
            _unitOfWork.Products.Update(product);
            _unitOfWork.Commit();
            return _mapper.Map<ProductDto>(product);
        }
    }
}
