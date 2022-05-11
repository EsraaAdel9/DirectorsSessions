namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewsession : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewSession",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Session_Num = c.String(nullable: false),
                        Session_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewSession");
        }
    }
}
