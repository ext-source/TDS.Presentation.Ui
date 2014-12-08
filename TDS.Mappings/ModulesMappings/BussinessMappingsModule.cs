using System.Data.Entity;

using Ninject;
using Ninject.Modules;

using TDS.DataAccess;
using TDS.DataAccess.Implementation;

namespace TDS.Mappings.ModulesMappings
{
    public class BussinessMappingsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork<DbContext>>()
                .To<UnitOfWork>()
                .WithConstructorArgument(typeof(IKernel), Kernel);
        }
    }
}