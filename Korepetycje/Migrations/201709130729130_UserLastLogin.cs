namespace Korepetycje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserLastLogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LastLoginDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LastLoginDate");
        }
    }
}
