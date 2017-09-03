namespace Korepetycje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResultsDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExerciseResults", "ExerciseId", "dbo.Exercises");
            DropIndex("dbo.ExerciseResults", new[] { "ExerciseId" });
            DropColumn("dbo.Exercises", "NumberOfResults");
            DropTable("dbo.ExerciseResults");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ExerciseResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExerciseId = c.Int(nullable: false),
                        ResultNumber = c.Int(nullable: false),
                        Result = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Exercises", "NumberOfResults", c => c.Int(nullable: false));
            CreateIndex("dbo.ExerciseResults", "ExerciseId");
            AddForeignKey("dbo.ExerciseResults", "ExerciseId", "dbo.Exercises", "Id");
        }
    }
}
