namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sub : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SessionSubjects", "Sub_File", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SessionSubjects", "Sub_File", c => c.String(nullable: false));
        }
    }
}
