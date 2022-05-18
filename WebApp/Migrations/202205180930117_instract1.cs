namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class instract1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SessionInstructions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NewSessionID = c.Int(nullable: false),
                        Sessionnstructions = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.NewSession", t => t.NewSessionID, cascadeDelete: true)
                .Index(t => t.NewSessionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SessionInstructions", "NewSessionID", "dbo.NewSession");
            DropIndex("dbo.SessionInstructions", new[] { "NewSessionID" });
            DropTable("dbo.SessionInstructions");
        }
    }
}
