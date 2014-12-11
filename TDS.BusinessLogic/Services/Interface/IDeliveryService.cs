using System.Collections.Generic;

using TDS.DataAccess.EntityModels;

namespace TDS.Business.Services.Interface
{
    public interface IDeliveryService<TObject> : IBaseService<TObject>
        where TObject : class
    {
        ICollection<DeliveryEntity> GetByProductId(int productId);
    }
}