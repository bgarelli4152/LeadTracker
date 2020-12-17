namespace LeadTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anothermigration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Interactions");
            DropColumn("dbo.Interactions", "ID");
            AddColumn("dbo.Interactions", "InteractionID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Interactions", "InteractionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Interactions", "ID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Interactions");
            DropColumn("dbo.Interactions", "InteractionID");
            AddPrimaryKey("dbo.Interactions", "ID");
        }
    }
}
