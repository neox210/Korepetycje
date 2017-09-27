namespace Korepetycje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class callendarEventsWithStudents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CallendarEvents", "StudentId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.CallendarEvents", "StudentId");
            AddForeignKey("dbo.CallendarEvents", "StudentId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CallendarEvents", "StudentId", "dbo.AspNetUsers");
            DropIndex("dbo.CallendarEvents", new[] { "StudentId" });
            DropColumn("dbo.CallendarEvents", "StudentId");
        }
    }
}
