namespace Korepetycje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDeletedProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Homeworks", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sections", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sections", "IsDeleted");
            DropColumn("dbo.Homeworks", "IsDeleted");
            DropColumn("dbo.Exercises", "IsDeleted");
        }
    }
}
