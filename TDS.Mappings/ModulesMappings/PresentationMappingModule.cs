using Ninject.Modules;

using TDS.Business.Services;
using TDS.Business.Services.Implementation;

namespace TDS.Mappings.ModulesMappings
{
    public class PresentationMappingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAccountService>()
                .To<AccountService>();
        }
    }
}