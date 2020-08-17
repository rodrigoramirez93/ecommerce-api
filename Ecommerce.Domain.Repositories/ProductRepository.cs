using Ecommerce.Domain.DAL;
using Ecommerce.Domain.Model;

namespace Ecommerce.Domain.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
