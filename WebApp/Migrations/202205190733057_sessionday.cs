namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sessionday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewSession", "Session_Day", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewSession", "Session_Day");
        }
    }
}
