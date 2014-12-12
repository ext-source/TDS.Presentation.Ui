using System.Collections.Generic;
using System.Linq;

using Ninject;

using TDS.Business.Services.Interface;
using TDS.DataAccess.EntityModels;

namespace TDS.Business.Services.Implementation
{
    public class PurchaseService : BaseService<PurchaseEntity>, IPurchaseService
    {
        public PurchaseService(IKernel kernel) : base(kernel)
        {
        }

        public PurchaseEntity GetByIdentity(string identity)
        {
            return ServiceRepo.GetBy(e => e.UserIdentity.Equals(identity)).FirstOrDefault();
        }

        public ICollection<PurchaseEntity> GetByAllIdentity(string identity)
        {
            return ServiceRepo.GetBy(e => e.UserIdentity.Equals(identity)).ToList();
        }
    }
}