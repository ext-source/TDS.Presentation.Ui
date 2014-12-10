using System;
using System.Collections.Generic;
using System.Linq;

using Ninject;

using TDS.Business.Services.Interface;
using TDS.DataAccess.EntityModels;

namespace TDS.Business.Services.Implementation
{
    public class ProductsService : BaseService<ProductEntity>, IProductsService<ProductEntity>
    {
        public ProductsService(IKernel kernel) 
            : base(kernel)
        {

        }

        public override ProductEntity Create(ProductEntity objectToCreate)
        {
            if (objectToCreate == null)
            {
                throw new ArgumentNullException("objectToCreate");
            }

            objectToCreate.CreateDate = DateTime.Now;
            objectToCreate.UpdateDate = objectToCreate.CreateDate;

            return base.Create(objectToCreate);
        }

        public override void Update(ProductEntity objectToUpdate)
        {
            ProductEntity existing = GetById(objectToUpdate.ProductEntityId);

            existing.Name = objectToUpdate.Name;
            existing.ProductInfo = objectToUpdate.ProductInfo;
            existing.Categories = objectToUpdate.Categories;
            existing.UpdateDate = DateTime.Now;

            UnitOfWork.SaveChanges();
        }

        public ICollection<ProductEntity> Search(string content)
        {
            return ServiceRepo.GetBy(e => e.Name.Contains(content)).ToList();
        }
    }
}