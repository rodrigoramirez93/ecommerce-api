using Ecommerce.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Domain.DAL
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext() : base()
        {

        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
