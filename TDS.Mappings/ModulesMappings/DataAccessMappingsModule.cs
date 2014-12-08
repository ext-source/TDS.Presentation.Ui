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
            Bind<IGenericRepository<CartEntity>>()
                .To<GenericRepository<CartEntity>>()
                .WithConstructorArgument(typeof(TContext), contextAdapter.Context);

            Bind<IGenericRepository<CategoryEntity>>()
                .To<GenericRepository<CategoryEntity>>()
                .WithConstructorArgument(typeof(TContext), contextAdapter.Context);

            Bind<IGenericRepository<ClientEntity>>()
                .To<GenericRepository<ClientEntity>>()
                .WithConstructorArgument(typeof(TContext), contextAdapter.Context);

            Bind<IGenericRepository<DeliveryEntity>>()
                .To<GenericRepository<DeliveryEntity>>()
                .WithConstructorArgument(typeof(TContext), contextAdapter.Context);

            Bind<IGenericRepository<PaymentEntity>>()
                .To<GenericRepository<PaymentEntity>>()
                .WithConstructorArgument(typeof(TContext), contextAdapter.Context);

            Bind<IGenericRepository<ProductEntity>>()
                .To<GenericRepository<ProductEntity>>()
                .WithConstructorArgument(typeof(TContext), contextAdapter.Context);

            Bind<IGenericRepository<ProviderEntity>>()
                .To<GenericRepository<ProviderEntity>>()
                .WithConstructorArgument(typeof(TContext), contextAdapter.Context);

            Bind<IGenericRepository<PurchaseEntity>>()
                .To<GenericRepository<PurchaseEntity>>()
                .WithConstructorArgument(typeof(TContext), contextAdapter.Context);

            Bind<IGenericRepository<UserProfileEntity>>()
                .To<GenericRepository<UserProfileEntity>>()
                .WithConstructorArgument(typeof(TContext), contextAdapter.Context);
        }
    }
}
