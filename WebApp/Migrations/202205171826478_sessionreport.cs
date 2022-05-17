namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sessionreport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SessionReports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NewSessionID = c.Int(nullable: false),
                        SessionFile = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.NewSession", t => t.NewSessionID, cascadeDelete: true)
                .Index(t => t.NewSessionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SessionReports", "NewSessionID", "dbo.NewSession");
            DropIndex("dbo.SessionReports", new[] { "NewSessionID" });
            DropTable("dbo.SessionReports");
        }
    }
}
