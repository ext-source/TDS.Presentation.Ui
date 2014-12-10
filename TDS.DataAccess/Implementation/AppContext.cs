using System.Data.Entity;

using Microsoft.AspNet.Identity.EntityFramework;

using TDS.DataAccess.EntityModels;

namespace TDS.DataAccess.Implementation
{
    public class AppContext : DbContext
    {
        public AppContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Database.SetInitializer<AppContext>(null);
            
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public DbSet<UserProfileEntity> UserProfileEntities
        {
            get;
            set;
        }

        public DbSet<PurchaseEntity> Purchases
        {
            get;
            set;
        }

        public DbSet<ProviderEntity> Providers
        {
            get;
            set;
        }

        public DbSet<ProductEntity> Products
        {
            get;
            set;
        }

        public DbSet<PaymentEntity> Payments
        {
            get;
            set;
        }

        public DbSet<DeliveryEntity> Deliveries
        {
            get;
            set;
        }

        public DbSet<ClientEntity> Clients
        {
            get;
            set;
        }

        public DbSet<CategoryEntity> Categories
        {
            get;
            set;
        }

        public DbSet<CartEntity> Carts
        {
            get;
            set;
        }
    }
}