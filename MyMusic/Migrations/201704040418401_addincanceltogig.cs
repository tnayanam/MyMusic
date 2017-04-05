namespace MyMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addincanceltogig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "isCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gigs", "isCanceled");
        }
    }
}
