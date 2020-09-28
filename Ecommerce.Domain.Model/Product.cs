using Ecommerce.Core;

namespace Ecommerce.Domain.Model
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public Organization Organization { get; set; }
        public int OrganizationId { get; set; }
    }
}
