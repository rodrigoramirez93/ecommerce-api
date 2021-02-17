using AutoMapper;
using Ecommerce.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Dto.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductToCreateDto, Product>();
            CreateMap<Product, CreatedProductDto>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
