namespace TwentyFourHour.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "Author", c => c.Guid(nullable: false));
            DropColumn("dbo.Post", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "UserId", c => c.Guid(nullable: false));
            DropColumn("dbo.Post", "Author");
        }
    }
}
