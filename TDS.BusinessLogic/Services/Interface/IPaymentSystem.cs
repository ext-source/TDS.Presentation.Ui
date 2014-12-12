using TDS.DataAccess.EntityModels;

namespace TDS.Business.Services.Interface
{
    public interface IPaymentSystem : IBaseService<PaymentEntity>
    {
        void MakeTransaction(int paymentNumber, int totalSum);
    }
}