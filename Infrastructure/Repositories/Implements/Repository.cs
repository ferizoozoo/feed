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

        // TODO: Should implement multiple includes later (params Expression<Func<TEntity, object>>[] includes)
        public T GetById(int id)
        {
            return _entitySet.Find(id);
        }

        // TODO: Should implement multiple includes later
        public async Task<T> GetByIdAsync(int id)
        {
            return await _entitySet.FindAsync(id);
        }

        // TODO: Should implement multiple includes later
        public List<T> GetAll(Expression<Func<T, object>> orderBy = null, bool isDescending = false)
        {
            var queryable = isDescending ? _entitySet.OrderByDescending(orderBy) : _entitySet.OrderByDescending(orderBy);
            return queryable.ToList();
        }

        // TODO: Should implement multiple includes later
        public async Task<List<T>> GetAllAsync(Expression<Func<T, object>> orderBy = null, bool isDescending = false)
        {
            var queryable = isDescending ? _entitySet.OrderByDescending(orderBy) : _entitySet.OrderByDescending(orderBy);
            return await queryable.ToListAsync();
        }

        // TODO: Should implement multiple includes later
        public T FirstOrDefault(Expression<Func<T, bool>> query)
        {
            return _entitySet.Where(query).FirstOrDefault();
        }

        // TODO: Should implement multiple includes later
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> query)
        {
            return await _entitySet.Where(query).FirstOrDefaultAsync();
        }

        // TODO: Should implement multiple includes later
        public List<T> Find(Expression<Func<T, bool>> query, Expression<Func<T, object>> orderBy = null, bool isDescending = false)
        {
            var queryable = isDescending ? _entitySet.Where(query).OrderByDescending(orderBy) : _entitySet.Where(query).OrderBy(orderBy);
            return queryable.ToList();
        }

        // TODO: Should implement multiple includes later
        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> query, Expression<Func<T, object>> orderBy = null, bool isDescending = false)
        {
            var queryable = isDescending ? _entitySet.Where(query).OrderByDescending(orderBy) : _entitySet.Where(query).OrderBy(orderBy);
            return await queryable.ToListAsync();
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