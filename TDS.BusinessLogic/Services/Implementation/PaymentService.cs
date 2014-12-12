using Ninject;

using TDS.Business.Services.Interface;
using TDS.DataAccess.EntityModels;

namespace TDS.Business.Services.Implementation
{
    public class PaymentService : BaseService<PaymentEntity>, IPaymentService
    {
        public PaymentService(IKernel kernel) : base(kernel)
        {
        }


        public int GetPaymentNumber(string identity)
        {
            return 123456789;
        }
    }
}