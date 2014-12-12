namespace TDS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCartUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cart", "UserIdentity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cart", "UserIdentity");
        }
    }
}
