namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class strsub2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MemoViewModels", "Name");
            DropColumn("dbo.MemoViewModels", "Img");
            DropColumn("dbo.MemoViewModels", "NewSessionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemoViewModels", "NewSessionID", c => c.Int(nullable: false));
            AddColumn("dbo.MemoViewModels", "Img", c => c.String());
            AddColumn("dbo.MemoViewModels", "Name", c => c.String(nullable: false));
        }
    }
}
