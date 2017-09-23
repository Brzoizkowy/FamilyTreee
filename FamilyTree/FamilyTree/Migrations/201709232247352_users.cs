namespace FamilyTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class users : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Task", "ListId", "dbo.List");
            DropIndex("dbo.Task", new[] { "ListId" });
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LasttName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropTable("dbo.List");
            DropTable("dbo.Task");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Ended = c.Boolean(nullable: false),
                        ListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.List",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.UserAccounts");
            CreateIndex("dbo.Task", "ListId");
            AddForeignKey("dbo.Task", "ListId", "dbo.List", "Id", cascadeDelete: true);
        }
    }
}
