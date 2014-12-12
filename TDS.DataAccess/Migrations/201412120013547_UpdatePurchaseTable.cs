namespace TDS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePurchaseTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchase", "UserIdentity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchase", "UserIdentity");
        }
    }
}
