namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MemoTypes",
                c => new
                    {
                        MemoID = c.Int(nullable: false, identity: true),
                        MemoName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MemoID);
            
            AddColumn("dbo.SessionSubjects", "MemoType_MemoID", c => c.Int());
            CreateIndex("dbo.SessionSubjects", "MemoType_MemoID");
            AddForeignKey("dbo.SessionSubjects", "MemoType_MemoID", "dbo.MemoTypes", "MemoID");
        }
    }
}
