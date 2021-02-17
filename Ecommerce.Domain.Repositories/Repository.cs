using Ecommerce.Core;
using Ecommerce.Domain.DAL;
using Ecommerce.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        internal DatabaseContext _context;
        internal DbSet<T> _dbSet;

        public Repository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<int> Create(T entity)
        {
            await _context.AddAsync(entity);
            return entity.Id;
        }

        public async Task<T> ReadAsync(int id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(_ => _.Id == id);
            return entity;
        }

        public async Task<IEnumerable<T>> ReadAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public T Update(T entity)
        {
            var entityToUpdate = _context.Set<T>().Find(entity.Id);
            _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
            return entity;
        }

        public async Task DeleteAsync(string entityName, int id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(_ => _.Id == id);
            entity.MustExist(entityName, id);
            _context.Remove(entity);
        }

        public async Task<IEnumerable<T>> ReadAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
