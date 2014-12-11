using System.Collections.Generic;
using System.Linq;

using Ninject;

using TDS.Business.Services.Interface;
using TDS.DataAccess.EntityModels;

namespace TDS.Business.Services.Implementation
{
    public class DeliveryService
        : BaseService<DeliveryEntity>, IDeliveryService<DeliveryEntity>
    {
        public DeliveryService(IKernel kernel) 
            : base(kernel)
        {
        }

        public ICollection<DeliveryEntity> GetByProductId(int productId)
        {
            return ServiceRepo.GetBy(e => e.ProductEntityId == productId).ToList();
        }
    }
}