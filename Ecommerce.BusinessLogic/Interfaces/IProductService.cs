using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.BusinessLogic.Interfaces
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
