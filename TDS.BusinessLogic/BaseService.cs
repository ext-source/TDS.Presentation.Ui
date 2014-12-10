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
        private readonly IUnitOfWork<DbContext> unitOfWork;

        protected BaseService(IKernel kernel)
        {
            this.kernel = kernel;
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }

            unitOfWork = kernel.Get<IUnitOfWork<DbContext>>();
        }

        public IGenericRepository<TObject> ServiceRepo
        {
            get
            {
                return unitOfWork.For<TObject>();
            }
        }

        public IUnitOfWork<DbContext> UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
        }

        public virtual ICollection<TObject> GetAll()
        {
            return unitOfWork.For<TObject>().GetAll().ToList();
        }

        public virtual TObject GetById(int id)
        {
            return unitOfWork.For<TObject>().GetById(id);
        }

        public virtual void Update(TObject objectToUpdate)
        {
            if (objectToUpdate == null)
            {
                throw new ArgumentNullException("objectToUpdate");
            }
            unitOfWork.For<TObject>().Update(objectToUpdate);
            unitOfWork.SaveChanges();
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

            TObject createdObject = unitOfWork.For<TObject>().Insert(objectToCreate);

            unitOfWork.SaveChanges();

            return createdObject;
        }

        public virtual void Delete(TObject objectToDelete)
        {
            if (objectToDelete == null)
            {
                throw new ArgumentNullException("objectToDelete");
            }
            unitOfWork.For<TObject>().Delete(objectToDelete);
            unitOfWork.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            unitOfWork.For<TObject>().Delete(id);
            unitOfWork.SaveChanges();
        }
    }
}
