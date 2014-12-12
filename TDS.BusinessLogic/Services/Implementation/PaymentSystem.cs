using Ninject;

using TDS.Business.Services.Interface;
using TDS.DataAccess.EntityModels;

namespace TDS.Business.Services.Implementation
{
    public class PaymentSystem : BaseService<PaymentEntity>, IPaymentSystem
    {
        public PaymentSystem(IKernel kernel) : base(kernel)
        {
        }

        public void MakeTransaction(int paymentNumber, int totalSum)
        {
            
        }
    }
}