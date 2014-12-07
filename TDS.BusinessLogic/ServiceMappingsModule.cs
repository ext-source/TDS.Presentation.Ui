using Ninject;
using Ninject.Modules;

using TDS.DataAccess;
using TDS.DataAccess.Implementation;

namespace TDS.Business
{
    internal class ServiceMappingsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork<AppContext>>()
                .To<UnitOfWork>()// todo: check this behaviour
                .WithConstructorArgument(typeof (IKernel), Kernel);
        }
    }
}
