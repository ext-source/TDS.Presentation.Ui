namespace TDS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDeliveryEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Delivery", "CartEntity_CartEntityId", "dbo.Cart");
            DropIndex("dbo.Delivery", new[] { "CartEntity_CartEntityId" });
            CreateTable(
                "dbo.DeliveryEntityCartEntities",
                c => new
                    {
                        DeliveryEntity_DeliveryEntityId = c.Int(nullable: false),
                        CartEntity_CartEntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DeliveryEntity_DeliveryEntityId, t.CartEntity_CartEntityId })
                .ForeignKey("dbo.Delivery", t => t.DeliveryEntity_DeliveryEntityId, cascadeDelete: true)
                .ForeignKey("dbo.Cart", t => t.CartEntity_CartEntityId, cascadeDelete: true)
                .Index(t => t.DeliveryEntity_DeliveryEntityId)
                .Index(t => t.CartEntity_CartEntityId);
            
            DropColumn("dbo.Delivery", "CartEntity_CartEntityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Delivery", "CartEntity_CartEntityId", c => c.Int());
            DropForeignKey("dbo.DeliveryEntityCartEntities", "CartEntity_CartEntityId", "dbo.Cart");
            DropForeignKey("dbo.DeliveryEntityCartEntities", "DeliveryEntity_DeliveryEntityId", "dbo.Delivery");
            DropIndex("dbo.DeliveryEntityCartEntities", new[] { "CartEntity_CartEntityId" });
            DropIndex("dbo.DeliveryEntityCartEntities", new[] { "DeliveryEntity_DeliveryEntityId" });
            DropTable("dbo.DeliveryEntityCartEntities");
            CreateIndex("dbo.Delivery", "CartEntity_CartEntityId");
            AddForeignKey("dbo.Delivery", "CartEntity_CartEntityId", "dbo.Cart", "CartEntityId");
        }
    }
}
