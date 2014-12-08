using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace TDS.DataAccess.Implementation
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> 
        where TEntity : class
    {
        private readonly AppContext context;
        private readonly DbSet<TEntity> dbSet;
        
        public GenericRepository(AppContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.context = context;
            
            dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetById(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] toInclude)
        {
            IQueryable<TEntity> query = dbSet;

            query = toInclude
               .Select(expr => ((MemberExpression)expr.Body).Member.Name)
               .Aggregate(query, (current, nameToInclude) => current.Include(nameToInclude));

            return query;
        }

        public virtual TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(int id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}