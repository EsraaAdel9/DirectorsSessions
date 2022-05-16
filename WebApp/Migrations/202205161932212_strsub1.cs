namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class strsub1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemoViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Img = c.String(),
                        NewSessionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MemoViewModels");
        }
    }
}
