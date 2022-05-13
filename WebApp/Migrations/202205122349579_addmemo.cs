namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmemo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemoTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SessionSubjects", "MemoTypesId", c => c.Int(nullable: false));
            CreateIndex("dbo.SessionSubjects", "MemoTypesId");
            AddForeignKey("dbo.SessionSubjects", "MemoTypesId", "dbo.MemoTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SessionSubjects", "MemoTypesId", "dbo.MemoTypes");
            DropIndex("dbo.SessionSubjects", new[] { "MemoTypesId" });
            DropColumn("dbo.SessionSubjects", "MemoTypesId");
            DropTable("dbo.MemoTypes");
        }
    }
}
