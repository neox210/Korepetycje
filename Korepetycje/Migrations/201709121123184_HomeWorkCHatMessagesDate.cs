namespace Korepetycje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HomeWorkCHatMessagesDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HomeworkChatMessages", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HomeworkChatMessages", "Date");
        }
    }
}
