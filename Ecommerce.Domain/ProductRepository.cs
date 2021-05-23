namespace Ecommerce.Domain
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
