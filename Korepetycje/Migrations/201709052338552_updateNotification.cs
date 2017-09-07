namespace Korepetycje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNotification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "FullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "FullName");
        }
    }
}
