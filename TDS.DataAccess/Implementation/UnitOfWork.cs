using System;
using System.Data.Entity;

using Ninject;

namespace TDS.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork<DbContext>
    {
        private bool disposed;

        private readonly IContextAdapter<DbContext> context;
        private readonly IKernel kernel;
        
        public UnitOfWork(
            IContextAdapter<DbContext> context, IKernel kernel)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }
            this.context = context;
            this.kernel = kernel;
        }

        public IContextAdapter<DbContext> ContextAdapter
        {
            get
            {
                return context;
            }
        }

        public IGenericRepository<TEntity> For<TEntity>() 
            where TEntity : class
        {
            return kernel.Get<IGenericRepository<TEntity>>();
        }

        public void Save()
        {
            ContextAdapter.Context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    ContextAdapter.Context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
