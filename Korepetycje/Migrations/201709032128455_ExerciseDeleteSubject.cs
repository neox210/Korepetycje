namespace Korepetycje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExerciseDeleteSubject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exercises", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Exercises", new[] { "SubjectId" });
            DropColumn("dbo.Exercises", "SubjectId");
            DropTable("dbo.Subjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Exercises", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Exercises", "SubjectId");
            AddForeignKey("dbo.Exercises", "SubjectId", "dbo.Subjects", "Id");
        }
    }
}
