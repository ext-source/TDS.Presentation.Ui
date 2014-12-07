using System;

using Ninject;
using Ninject.Parameters;

using TDS.DataAccess;
using TDS.DataAccess.Implementation;

namespace TDS.Business
{
    public abstract class BaseService
    {
        private readonly IKernel kernel;
        protected readonly IUnitOfWork<AppContext> UnitOfWork;

        protected BaseService(IKernel kernel)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }

            this.kernel = kernel;
            
            if (!kernel.HasModule(typeof(ServiceMappingsModule).FullName))
            {
                kernel.Load<ServiceMappingsModule>();
            }

            UnitOfWork = kernel.Get<IUnitOfWork<AppContext>>();
        }
    }
}
