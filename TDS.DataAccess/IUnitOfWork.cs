using System;
using System.Data.Entity;

namespace TDS.DataAccess
{
    public interface IUnitOfWork<out TContext> : IDisposable
        where TContext : DbContext
    {
        IContextAdapter<TContext> ContextAdapter
        {
            get;
        }

        IGenericRepository<TEntity> Get<TEntity>()
            where TEntity : class;
    }
}