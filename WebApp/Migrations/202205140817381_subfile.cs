namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SessionSubjects", "Sub_File", c => c.String(nullable: false));
            DropColumn("dbo.SessionSubjects", "Sub_Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SessionSubjects", "Sub_Description", c => c.String(nullable: false, maxLength: 2000));
            DropColumn("dbo.SessionSubjects", "Sub_File");
        }
    }
}
