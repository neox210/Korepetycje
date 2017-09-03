namespace Korepetycje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchoolUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SchoolClassLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SchoolLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Exercises", "SchoolListId", c => c.Int(nullable: false));
            AddColumn("dbo.Exercises", "SchoolClassListId", c => c.Int(nullable: false));
            CreateIndex("dbo.Exercises", "SchoolListId");
            CreateIndex("dbo.Exercises", "SchoolClassListId");
            AddForeignKey("dbo.Exercises", "SchoolClassListId", "dbo.SchoolClassLists", "Id");
            AddForeignKey("dbo.Exercises", "SchoolListId", "dbo.SchoolLists", "Id");
            DropColumn("dbo.Exercises", "SchoolLevel");
            DropColumn("dbo.Exercises", "Class");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exercises", "Class", c => c.Int(nullable: false));
            AddColumn("dbo.Exercises", "SchoolLevel", c => c.String(nullable: false));
            DropForeignKey("dbo.Exercises", "SchoolListId", "dbo.SchoolLists");
            DropForeignKey("dbo.Exercises", "SchoolClassListId", "dbo.SchoolClassLists");
            DropIndex("dbo.Exercises", new[] { "SchoolClassListId" });
            DropIndex("dbo.Exercises", new[] { "SchoolListId" });
            DropColumn("dbo.Exercises", "SchoolClassListId");
            DropColumn("dbo.Exercises", "SchoolListId");
            DropTable("dbo.SchoolLists");
            DropTable("dbo.SchoolClassLists");
        }
    }
}
