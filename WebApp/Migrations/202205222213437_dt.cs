namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SessionSubjects", "Sub_File", c => c.String());
            AlterColumn("dbo.SessionReports", "SessionFile", c => c.String());
            AlterColumn("dbo.SessionInstructions", "Sessionnstructions", c => c.String());
            AlterColumn("dbo.SessionSchedules", "ScheduleFile", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SessionSchedules", "ScheduleFile", c => c.String(nullable: false));
            AlterColumn("dbo.SessionInstructions", "Sessionnstructions", c => c.String(nullable: false));
            AlterColumn("dbo.SessionReports", "SessionFile", c => c.String(nullable: false));
            AlterColumn("dbo.SessionSubjects", "Sub_File", c => c.String(nullable: false));
        }
    }
}
