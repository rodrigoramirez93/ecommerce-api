using Ecommerce.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ecommerce.Domain.DAL
{
    public class DatabaseContext: IdentityDbContext<User, Role, Guid>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>().HasData(DummyService.GetProductDummyData());
        }

        public DbSet<Product> Products { get; set; }
    }
}
