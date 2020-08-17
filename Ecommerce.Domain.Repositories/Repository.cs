using Ecommerce.Core;
using Ecommerce.Domain.DAL;
using Ecommerce.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


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

        public int Create(T entity)
        {
            _context.Add(entity);
            return entity.Id;
        }

        public T Read(int id)
        {
            var entity = _dbSet.FirstOrDefault(_ => _.Id == id);
            return entity;
        }

        public IEnumerable<T> Read(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public T Update(T entity)
        {
            _dbSet.Attach(entity);
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
            return entity;
        }

        public void Delete(int id)
        {
            var entity = _dbSet.First(_ => _.Id == id);
            _context.Remove(entity);
        }

        public IEnumerable<T> Read()
        {
            return _dbSet.ToList();
        }
    }
}
