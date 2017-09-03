namespace Korepetycje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upadteHomework : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Homeworks", "TaskDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Homeworks", "TaskDateTime");
        }
    }
}
