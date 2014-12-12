using TDS.DataAccess.EntityModels;

namespace TDS.Business.Services.Interface
{
    public interface ICartService : IBaseService<CartEntity>
    {
        CartEntity GetOrCreate(string identity);

        void AddDelivery(string identity, DeliveryEntity delivery);

        void ClearCart(string identity);
    }
}