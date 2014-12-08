using System.Data.Entity.Migrations;

namespace TDS.DataAccess.Migrations
{
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        CartEntityId = c.Int(nullable: false, identity: true),
                        Total = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CartEntityId);
            
            CreateTable(
                "dbo.Delivery",
                c => new
                    {
                        DeliveryEntityId = c.Int(nullable: false, identity: true),
                        ProductEntityId = c.Int(nullable: false),
                        ProviderEntityId = c.Int(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Count = c.Int(nullable: false),
                        Cost = c.Int(nullable: false),
                        CartEntity_CartEntityId = c.Int(),
                        PurchaseEntity_PurchaseEntityId = c.Int(),
                    })
                .PrimaryKey(t => t.DeliveryEntityId)
                .ForeignKey("dbo.Cart", t => t.CartEntity_CartEntityId)
                .ForeignKey("dbo.Purchase", t => t.PurchaseEntity_PurchaseEntityId)
                .Index(t => t.CartEntity_CartEntityId)
                .Index(t => t.PurchaseEntity_PurchaseEntityId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryEntityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProductEntity_ProductEntityId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryEntityId)
                .ForeignKey("dbo.Product", t => t.ProductEntity_ProductEntityId)
                .Index(t => t.ProductEntity_ProductEntityId);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientEntityId = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Cart_CartEntityId = c.Int(),
                    })
                .PrimaryKey(t => t.ClientEntityId)
                .ForeignKey("dbo.Cart", t => t.Cart_CartEntityId)
                .Index(t => t.Cart_CartEntityId);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        PurchaseEntityId = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        AdditionalInfo = c.String(),
                        Total = c.Int(nullable: false),
                        Payment_PaymentEntityId = c.Int(),
                        ClientEntity_ClientEntityId = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseEntityId)
                .ForeignKey("dbo.Payment", t => t.Payment_PaymentEntityId)
                .ForeignKey("dbo.Client", t => t.ClientEntity_ClientEntityId)
                .Index(t => t.Payment_PaymentEntityId)
                .Index(t => t.ClientEntity_ClientEntityId);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        PaymentEntityId = c.Int(nullable: false, identity: true),
                        PaymentNumber = c.Int(nullable: false),
                        PaymentSystemName = c.String(),
                        ClientEntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentEntityId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductEntityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                        ProductInfo = c.String(),
                    })
                .PrimaryKey(t => t.ProductEntityId);
            
            CreateTable(
                "dbo.Provider",
                c => new
                    {
                        ProviderEntityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                        IndividualNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProviderEntityId);
            
            CreateTable(
                "dbo.IdentityUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfile", "Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserRoles", "UserId", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserRoles", "RoleId", "dbo.IdentityRoles");
            DropForeignKey("dbo.IdentityUserLogins", "User_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserClaims", "User_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.Category", "ProductEntity_ProductEntityId", "dbo.Product");
            DropForeignKey("dbo.Purchase", "ClientEntity_ClientEntityId", "dbo.Client");
            DropForeignKey("dbo.Purchase", "Payment_PaymentEntityId", "dbo.Payment");
            DropForeignKey("dbo.Delivery", "PurchaseEntity_PurchaseEntityId", "dbo.Purchase");
            DropForeignKey("dbo.Client", "Cart_CartEntityId", "dbo.Cart");
            DropForeignKey("dbo.Delivery", "CartEntity_CartEntityId", "dbo.Cart");
            DropIndex("dbo.UserProfile", new[] { "Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "RoleId" });
            DropIndex("dbo.IdentityUserLogins", new[] { "User_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "User_Id" });
            DropIndex("dbo.Purchase", new[] { "ClientEntity_ClientEntityId" });
            DropIndex("dbo.Purchase", new[] { "Payment_PaymentEntityId" });
            DropIndex("dbo.Client", new[] { "Cart_CartEntityId" });
            DropIndex("dbo.Category", new[] { "ProductEntity_ProductEntityId" });
            DropIndex("dbo.Delivery", new[] { "PurchaseEntity_PurchaseEntityId" });
            DropIndex("dbo.Delivery", new[] { "CartEntity_CartEntityId" });
            DropTable("dbo.UserProfile");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.IdentityUsers");
            DropTable("dbo.Provider");
            DropTable("dbo.Product");
            DropTable("dbo.Payment");
            DropTable("dbo.Purchase");
            DropTable("dbo.Client");
            DropTable("dbo.Category");
            DropTable("dbo.Delivery");
            DropTable("dbo.Cart");
        }
    }
}
