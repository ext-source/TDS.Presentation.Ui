using Ninject;

using TDS.Business.Services.Interface;
using TDS.DataAccess.EntityModels;

namespace TDS.Business.Services.Implementation
{
    public class ProviderService : BaseService<ProviderEntity>, IProviderService<ProviderEntity>
    {
        public ProviderService(IKernel kernel) : base(kernel)
        {
        }
    }
}