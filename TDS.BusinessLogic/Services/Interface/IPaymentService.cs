using TDS.DataAccess.EntityModels;

namespace TDS.Business.Services.Interface
{
    public interface IPaymentService : IBaseService<PaymentEntity>
    {
        int GetPaymentNumber(string identity);
    }
}