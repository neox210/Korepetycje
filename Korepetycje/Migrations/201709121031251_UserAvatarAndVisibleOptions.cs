namespace Korepetycje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAvatarAndVisibleOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AvatarPath", c => c.String());
            AddColumn("dbo.AspNetUsers", "Visible", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Visible");
            DropColumn("dbo.AspNetUsers", "AvatarPath");
        }
    }
}
