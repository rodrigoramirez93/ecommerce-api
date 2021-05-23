namespace Ecommerce.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }
        void Commit();
    }
}
