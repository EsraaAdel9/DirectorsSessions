namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class strsub : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SessionSubjects", "Sub_ID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SessionSubjects", "Sub_ID", c => c.Int(nullable: false));
        }
    }
}
