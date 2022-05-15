namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgcol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemoTypes", "Img", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MemoTypes", "Img");
        }
    }
}
