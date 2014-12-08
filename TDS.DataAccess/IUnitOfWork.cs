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

        IGenericRepository<TEntity> For<TEntity>()
            where TEntity : class;
    }
}