using Ecommerce.Core;
using Ecommerce.Domain.DAL;
using Ecommerce.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Domain.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        internal DatabaseContext _context;
        internal DbSet<T> _dbSet;

        public Repository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T Create(T entity)
        {
            _context.Add(entity);
            return entity;
        }

        public T Delete(int id)
        {
            var entity = _dbSet.First(_ => _.Id == id);
            _context.Remove(entity);
            return entity;
        }

        public T Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> Read()
        {
            throw new System.NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
