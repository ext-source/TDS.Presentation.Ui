using System;

using Ninject;

using TDS.DataAccess.Mappings;

namespace TDS.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork<AppContext>
    {
        private bool disposed;

        private readonly IKernel kernel;
        private readonly IContextAdapter<AppContext> contextAdapterAdapter = 
            new ContextAdapter<AppContext>(new AppContext());

        public UnitOfWork(IKernel kernel)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }
            this.kernel = kernel;

            if (!kernel.HasModule(typeof (RepositoryMappingsModule<AppContext>).FullName))
            {
                kernel.Load(new RepositoryMappingsModule<AppContext>(contextAdapterAdapter));
            }
        }

        public IContextAdapter<AppContext> ContextAdapter
        {
            get
            {
                return contextAdapterAdapter;
            }
        }

        public IGenericRepository<TEntity> Get<TEntity>() 
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
