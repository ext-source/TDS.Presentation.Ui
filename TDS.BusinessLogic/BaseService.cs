using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Ninject;

using TDS.DataAccess;

namespace TDS.Business
{
    public abstract class BaseService<TObject> : IBaseService<TObject>
        where TObject : class 
    {
        private readonly IKernel kernel;
        protected readonly IUnitOfWork<DbContext> UnitOfWork;

        protected BaseService(IKernel kernel)
        {
            this.kernel = kernel;
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }

            UnitOfWork = kernel.Get<IUnitOfWork<DbContext>>();
        }

        public virtual ICollection<TObject> GetAll()
        {
            return UnitOfWork.For<TObject>().GetAll().ToList();
        }

        public virtual TObject GetById(int id)
        {
            return UnitOfWork.For<TObject>().GetById(id);
        }

        public virtual void Update(TObject objectToUpdate)
        {
            if (objectToUpdate == null)
            {
                throw new ArgumentNullException("objectToUpdate");
            }
            UnitOfWork.For<TObject>().Update(objectToUpdate);
            UnitOfWork.SaveChanges();
        }

        public virtual TObject Create()
        {
            return kernel.Get<TObject>();
        }

        public virtual TObject Create(TObject objectToCreate)
        {
            if (objectToCreate == null)
            {
                throw new ArgumentNullException("objectToCreate");
            }

            TObject createdObject = UnitOfWork.For<TObject>().Insert(objectToCreate);

            UnitOfWork.SaveChanges();

            return createdObject;
        }

        public virtual void Delete(TObject objectToDelete)
        {
            if (objectToDelete == null)
            {
                throw new ArgumentNullException("objectToDelete");
            }
            UnitOfWork.For<TObject>().Delete(objectToDelete);
            UnitOfWork.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            UnitOfWork.For<TObject>().Delete(id);
            UnitOfWork.SaveChanges();
        }
    }
}
