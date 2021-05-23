using Ecommerce.Domain.Interfaces;

namespace Ecommerce.Domain
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
