using AutoMapper;
using Ecommerce.Business.Dto;
using Ecommerce.Business.Dto.Validators;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core;
using Ecommerce.Domain.Model;
using Ecommerce.Domain.Repositories.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Ecommerce.Business.Services
{
    public class ProductServiceDto: IServiceDto<ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductServiceDto(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ProductDto Create(ProductDto entity)
        {
            DtoHelper.Validate<ProductDtoValidator, ProductDto>(entity);
            var product = _mapper.Map<Product>(entity);
            var response = _unitOfWork.Products.Create(product);
            _unitOfWork.Commit();
            return _mapper.Map<ProductDto>(response);
        }

        public ProductDto Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProductDto Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDto> Read()
        {
            throw new NotImplementedException();
        }

        public ProductDto Update(ProductDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
