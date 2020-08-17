using Ecommerce.Domain.Model;

namespace Ecommerce.Domain.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }

        void Commit();
    }
}
