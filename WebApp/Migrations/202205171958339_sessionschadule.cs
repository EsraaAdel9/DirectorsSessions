namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sessionschadule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SessionSchedules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NewSessionID = c.Int(nullable: false),
                        ScheduleFile = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.NewSession", t => t.NewSessionID, cascadeDelete: true)
                .Index(t => t.NewSessionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SessionSchedules", "NewSessionID", "dbo.NewSession");
            DropIndex("dbo.SessionSchedules", new[] { "NewSessionID" });
            DropTable("dbo.SessionSchedules");
        }
    }
}
