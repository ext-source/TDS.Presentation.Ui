using Ninject.Modules;

using TDS.Business.Services.Implementation;
using TDS.Business.Services.Interface;
using TDS.DataAccess.EntityModels;

namespace TDS.Mappings.ModulesMappings
{
    public class PresentationMappingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAccountService>()
                .To<AccountService>();

            Bind<IProductsService<ProductEntity>>()
                .To<ProductsService>();

            Bind<ICategoryService<CategoryEntity>>()
                .To<CategoryService>();

            Bind<IDeliveryService<DeliveryEntity>>()
                .To<DeliveryService>();

            Bind<IProviderService<ProviderEntity>>()
                .To<ProviderService>();
        }
    }
}