using System.Data.Entity.Migrations;

namespace TDS.DataAccess.Migrations
{
    public partial class UpdateDeliveryEntity1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.DeliveryEntityCartEntities");
        }

        public override void Down()
        {
            AddPrimaryKey("dbo.DeliveryEntityCartEntities", new[] { "DeliveryEntity_DeliveryEntityId", "CartEntity_CartEntityId" });
        }
    }
}
