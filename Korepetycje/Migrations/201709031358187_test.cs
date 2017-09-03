namespace Korepetycje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Homeworks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.String(nullable: false, maxLength: 128),
                        ExerciseId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercises", t => t.ExerciseId)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.ExerciseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Homeworks", "StudentId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Homeworks", "ExerciseId", "dbo.Exercises");
            DropIndex("dbo.Homeworks", new[] { "ExerciseId" });
            DropIndex("dbo.Homeworks", new[] { "StudentId" });
            DropTable("dbo.Homeworks");
        }
    }
}
