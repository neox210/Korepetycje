namespace Korepetycje.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class homeworkDateTimeUpdate : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.Homeworks DROP CONSTRAINT DF__Homeworks__TaskD__3A4CA8FD");
            AlterColumn("dbo.Homeworks", "TaskDateTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Homeworks", "TaskDateTime", c => c.DateTime(nullable: false));
            Sql("ALTER TABLE dbo.Homeworks CONSTRAINT DF__Homeworks__TaskD__3A4CA8FD");
        }
    }
}
