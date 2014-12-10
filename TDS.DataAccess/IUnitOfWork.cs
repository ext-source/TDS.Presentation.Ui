using System;
using System.Data.Entity;

namespace TDS.DataAccess
{
    public interface IUnitOfWork<out TContext> : IDisposable
        where TContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        IContextAdapter<TContext> ContextAdapter
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IGenericRepository<TEntity> For<TEntity>()
            where TEntity : class;

        /// <summary>
        /// 
        /// </summary>
        void SaveChanges();
    }
}