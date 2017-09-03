namespace Korepetycje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExercisesSubjectsSections : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        SectionId = c.Int(nullable: false),
                        Topic = c.String(nullable: false),
                        Content = c.String(),
                        NumberOfResults = c.Int(nullable: false),
                        FotoPath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.SectionId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId)
                .Index(t => t.SectionId);
            
            CreateTable(
                "dbo.ExerciseResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExerciseId = c.Int(nullable: false),
                        ResultNumber = c.Int(nullable: false),
                        Result = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercises", t => t.ExerciseId)
                .Index(t => t.ExerciseId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercises", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Exercises", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.ExerciseResults", "ExerciseId", "dbo.Exercises");
            DropIndex("dbo.ExerciseResults", new[] { "ExerciseId" });
            DropIndex("dbo.Exercises", new[] { "SectionId" });
            DropIndex("dbo.Exercises", new[] { "SubjectId" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Sections");
            DropTable("dbo.ExerciseResults");
            DropTable("dbo.Exercises");
        }
    }
}
