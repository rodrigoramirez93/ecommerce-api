using Ecommerce.Business.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface IProductService
    {
         Task<CreatedProductDto> CreateAsync(ProductToCreateDto entity);

         Task DeleteAsync(int id);

         Task<ProductDto> ReadAsync(int id);

         Task<IEnumerable<ProductDto>> ReadAsync();

         Task<ProductDto> UpdateAsync(UpdateProductDto entity);
    }
}
