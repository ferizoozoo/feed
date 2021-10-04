using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using feed.Infrastructure.Repositories.Interfaces;

namespace feed.Infrastructure.Repositories.Implements
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _entitySet;

        public Repository(DbContext context)
        {
            _entitySet = context.Set<T>();
        }

        public T GetById(int id)
        {
            return _entitySet.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entitySet.FindAsync(id);
        }

        public List<T> GetAll()
        {
            return _entitySet.ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _entitySet.ToListAsync();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _entitySet.Where(predicate).FirstOrDefault();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entitySet.Where(predicate).FirstOrDefaultAsync();
        }


        public List<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _entitySet.Where(predicate).ToList();
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entitySet.Where(predicate).ToListAsync();
        }

        public void Add(T entity)
        {
            _entitySet.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _entitySet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entitySet.Update(entity);
        }

        public void Delete(T entity)
        {
            _entitySet.Remove(entity);
        }

        public void DeleteById(int id)
        {
            var entity = _entitySet.Find(id);
            _entitySet.Remove(entity);
        }
    }
}