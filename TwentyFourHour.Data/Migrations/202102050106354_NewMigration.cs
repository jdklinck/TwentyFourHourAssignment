namespace TwentyFourHour.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reply", "PostId", "dbo.Post");
            DropForeignKey("dbo.Reply", "Reply_Id", "dbo.Reply");
            DropForeignKey("dbo.Reply", "Comment_Id", "dbo.Comment");
            DropIndex("dbo.Reply", new[] { "PostId" });
            DropIndex("dbo.Reply", new[] { "Reply_Id" });
            DropIndex("dbo.Reply", new[] { "Comment_Id" });
            RenameColumn(table: "dbo.Reply", name: "Comment_Id", newName: "CommentId");
            AddColumn("dbo.Comment", "Author", c => c.Guid(nullable: false));
            AlterColumn("dbo.Reply", "CommentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reply", "CommentId");
            AddForeignKey("dbo.Reply", "CommentId", "dbo.Comment", "Id", cascadeDelete: true);
            DropColumn("dbo.Reply", "PostId");
            DropColumn("dbo.Reply", "Reply_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reply", "Reply_Id", c => c.Int());
            AddColumn("dbo.Reply", "PostId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropIndex("dbo.Reply", new[] { "CommentId" });
            AlterColumn("dbo.Reply", "CommentId", c => c.Int());
            DropColumn("dbo.Comment", "Author");
            RenameColumn(table: "dbo.Reply", name: "CommentId", newName: "Comment_Id");
            CreateIndex("dbo.Reply", "Comment_Id");
            CreateIndex("dbo.Reply", "Reply_Id");
            CreateIndex("dbo.Reply", "PostId");
            AddForeignKey("dbo.Reply", "Comment_Id", "dbo.Comment", "Id");
            AddForeignKey("dbo.Reply", "Reply_Id", "dbo.Reply", "Id");
            AddForeignKey("dbo.Reply", "PostId", "dbo.Post", "Id", cascadeDelete: true);
        }
    }
}
