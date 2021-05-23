using Ecommerce.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ecommerce.Domain.DAL
{
    public class DatabaseContext:  DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>().HasData(DummyService.GetProductDummyData());
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Product> Products { get; set; }
    }
}
