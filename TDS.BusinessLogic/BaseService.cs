using System;
using System.Data.Entity;

using Ninject;

using TDS.DataAccess;

namespace TDS.Business
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork<DbContext> UnitOfWork;

        protected BaseService(IKernel kernel)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }

            UnitOfWork = kernel.Get<IUnitOfWork<DbContext>>();
        }
    }
}
