namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsubjects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SessionSubjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Sub_ID = c.Int(nullable: false),
                        Sub_Name = c.String(nullable: false, maxLength: 250),
                        Sub_Description = c.String(nullable: false, maxLength: 2000),
                        NewSessionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.NewSession", t => t.NewSessionID, cascadeDelete: true)
                .Index(t => t.NewSessionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SessionSubjects", "NewSessionID", "dbo.NewSession");
            DropIndex("dbo.SessionSubjects", new[] { "NewSessionID" });
            DropTable("dbo.SessionSubjects");
        }
    }
}
