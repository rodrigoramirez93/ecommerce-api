using Ecommerce.Domain.Model;
using Ecommerce.Domain.Model.Identity;

namespace Ecommerce.Domain.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }
        void Commit();
    }
}
