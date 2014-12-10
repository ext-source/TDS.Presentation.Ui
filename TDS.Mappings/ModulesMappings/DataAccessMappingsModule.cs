using System;

using Ninject.Modules;

using TDS.DataAccess;
using TDS.DataAccess.EntityModels;
using TDS.DataAccess.Implementation;

namespace TDS.Mappings.ModulesMappings
{
    public class DataAccessMappingModule<TContext> : NinjectModule
    {
        private readonly IContextAdapter<TContext> contextAdapter;

        public DataAccessMappingModule(IContextAdapter<TContext> contextAdapter)
        {
            if (contextAdapter == null)
            {
                throw new ArgumentNullException("contextAdapter");
            }
            this.contextAdapter = contextAdapter;
        }

        public override void Load()
        {
            RegisterRepositories();

            Bind<ProductEntity>().ToSelf();
        }

        private void RegisterRepositories()
        {
            Bind<IGenericRepository<CartEntity>>()
                .To<GenericRepository<CartEntity>>();

            Bind<IGenericRepository<CategoryEntity>>()
                .To<GenericRepository<CategoryEntity>>();

            Bind<IGenericRepository<ClientEntity>>()
                .To<GenericRepository<ClientEntity>>();

            Bind<IGenericRepository<DeliveryEntity>>()
                .To<GenericRepository<DeliveryEntity>>();

            Bind<IGenericRepository<PaymentEntity>>()
                .To<GenericRepository<PaymentEntity>>();

            Bind<IGenericRepository<ProductEntity>>()
                .To<GenericRepository<ProductEntity>>();

            Bind<IGenericRepository<ProviderEntity>>()
                .To<GenericRepository<ProviderEntity>>();

            Bind<IGenericRepository<PurchaseEntity>>()
                .To<GenericRepository<PurchaseEntity>>();

            Bind<IGenericRepository<UserProfileEntity>>()
                .To<GenericRepository<UserProfileEntity>>();
        }
    }
}
