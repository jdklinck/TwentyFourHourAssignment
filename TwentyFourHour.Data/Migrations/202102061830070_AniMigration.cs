namespace TwentyFourHour.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AniMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            AddColumn("dbo.Comment", "Reply_Id", c => c.Int());
            AddColumn("dbo.Reply", "Author", c => c.Guid(nullable: false));
            AddColumn("dbo.Reply", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Reply", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Reply", "Comment_Id", c => c.Int());
            CreateIndex("dbo.Comment", "Reply_Id");
            CreateIndex("dbo.Reply", "Comment_Id");
            AddForeignKey("dbo.Comment", "Reply_Id", "dbo.Reply", "Id");
            AddForeignKey("dbo.Reply", "Comment_Id", "dbo.Comment", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reply", "Comment_Id", "dbo.Comment");
            DropForeignKey("dbo.Comment", "Reply_Id", "dbo.Reply");
            DropIndex("dbo.Reply", new[] { "Comment_Id" });
            DropIndex("dbo.Comment", new[] { "Reply_Id" });
            DropColumn("dbo.Reply", "Comment_Id");
            DropColumn("dbo.Reply", "ModifiedUtc");
            DropColumn("dbo.Reply", "CreatedUtc");
            DropColumn("dbo.Reply", "Author");
            DropColumn("dbo.Comment", "Reply_Id");
            AddForeignKey("dbo.Reply", "CommentId", "dbo.Comment", "Id", cascadeDelete: true);
        }
    }
}
