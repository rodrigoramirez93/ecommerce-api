using AutoMapper;
using Ecommerce.Domain;

namespace Ecommerce.BusinessLogic.Mappings
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
