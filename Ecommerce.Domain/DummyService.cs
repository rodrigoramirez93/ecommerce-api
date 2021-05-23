using System.Collections.Generic;

namespace Ecommerce.Domain
{
    internal class DummyService
    {
        public DummyService()
        {

        }

        internal static IEnumerable<Product> GetProductDummyData()
        {
            var list = new List<Product>()
            {
                new Product(){ Id = 1, Name = "Caramelos", Description = "Ricolinos", Price = 10, Stock = 2, OrganizationId = 1 },
                new Product(){ Id = 2, Name = "Chocolates", Description = "Acaso", Price = 5, Stock = 3, OrganizationId = 2 }
            };

            return list;
        }
    }
}