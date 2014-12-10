using System.Linq;

using Ninject;

using TDS.Business.Services.Interface;
using TDS.DataAccess.EntityModels;

namespace TDS.Business.Services.Implementation
{
    public class CartService : BaseService<CartEntity>, ICartService
    {
        public CartService(IKernel kernel)
            : base(kernel)
        {
        }

        public void Test()
        {
            int count = UnitOfWork.For<CartEntity>()
                .GetAll()
                .Count();
        }
    }
}