using Ecommerce.Domain.DAL;
using Ecommerce.Domain.Model;
using Ecommerce.Domain.Repositories.Interfaces;

namespace Ecommerce.Domain.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext _context;
        private Repository<Product> _productRepository;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IRepository<Product> Products
        {
            get
            {
                return _productRepository ?? (_productRepository = new Repository<Product>(_context));
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
