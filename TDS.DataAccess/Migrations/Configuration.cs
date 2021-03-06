using System.Data.Entity;
using System.Data.Entity.Migrations;

using TDS.DataAccess.EntityModels;
using TDS.DataAccess.Implementation;

namespace TDS.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Set<CategoryEntity>().AddOrUpdate(
                    new CategoryEntity { Name = "Music clips" },
                    new CategoryEntity { Name = "Scientific films" },
                    new CategoryEntity { Name = "Movies and TV series" }
                );

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
