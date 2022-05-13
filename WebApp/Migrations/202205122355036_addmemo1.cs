namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmemo1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SessionSubjects", new[] { "MemoTypesId" });
            CreateIndex("dbo.SessionSubjects", "MemoTypesID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SessionSubjects", new[] { "MemoTypesID" });
            CreateIndex("dbo.SessionSubjects", "MemoTypesId");
        }
    }
}
