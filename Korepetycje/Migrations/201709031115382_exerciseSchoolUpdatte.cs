namespace Korepetycje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exerciseSchoolUpdatte : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "SchoolLevel", c => c.String(nullable: false));
            AddColumn("dbo.Exercises", "Class", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercises", "Class");
            DropColumn("dbo.Exercises", "SchoolLevel");
        }
    }
}
