using System.Collections.Generic;

using TDS.DataAccess.EntityModels;

namespace TDS.Business.Services.Interface
{
    public interface IPurchaseService : IBaseService<PurchaseEntity>
    {
        PurchaseEntity GetByIdentity(string identity);

        ICollection<PurchaseEntity> GetByAllIdentity(string identity);
    }
}