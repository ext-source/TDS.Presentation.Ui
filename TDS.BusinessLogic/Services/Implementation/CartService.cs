using System;
using System.Data.Entity;
using System.Linq;

using TDS.DataAccess;
using TDS.DataAccess.EntityModels;

namespace TDS.Business.Services.Implementation
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork<DbContext> unitOfWork;

        public CartService(IUnitOfWork<DbContext> unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }
            this.unitOfWork = unitOfWork;
        }

        public void Test()
        {
            int count = unitOfWork.For<CartEntity>()
                .GetAll()
                .Count();
        }
    }
}