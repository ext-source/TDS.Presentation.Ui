using System;
using System.Linq;
using System.Linq.Expressions;

namespace TDS.DataAccess
{
    public interface IGenericRepository<TEntity> 
        where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toInclude"></param>
        /// <returns></returns>
        IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] toInclude);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Insert(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityToDelete"></param>
        void Delete(TEntity entityToDelete);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityToUpdate"></param>
        void Update(TEntity entityToUpdate);
    }
}