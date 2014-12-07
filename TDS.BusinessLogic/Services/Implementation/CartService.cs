using System.Collections.Generic;
using System.Linq;

using Ninject;

using TDS.DataAccess.EntityModels;

namespace TDS.Business.Services.Implementation
{
    public class CartService : BaseService, ICartService
    {
        public CartService(IKernel kernel) 
            : base(kernel)
        {
        }

        public void Test()
        {
            IEnumerable<CartEntity> carts = UnitOfWork
                .Get<CartEntity>()
                .Include(e => e.Deliveries)
                .Where(e => e.Count > 0)
                .ToList();
        }
    }
}