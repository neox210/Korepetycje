namespace Korepetycje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHomeworkCHatMessages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HomeworkChatMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.String(nullable: false, maxLength: 128),
                        HomeworkId = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        FotoPath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentId)
                .ForeignKey("dbo.Homeworks", t => t.HomeworkId)
                .Index(t => t.StudentId)
                .Index(t => t.HomeworkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HomeworkChatMessages", "HomeworkId", "dbo.Homeworks");
            DropForeignKey("dbo.HomeworkChatMessages", "StudentId", "dbo.AspNetUsers");
            DropIndex("dbo.HomeworkChatMessages", new[] { "HomeworkId" });
            DropIndex("dbo.HomeworkChatMessages", new[] { "StudentId" });
            DropTable("dbo.HomeworkChatMessages");
        }
    }
}
