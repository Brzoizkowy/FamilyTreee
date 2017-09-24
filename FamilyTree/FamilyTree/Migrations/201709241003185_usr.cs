namespace FamilyTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAccounts", "FirstName", c => c.String());
            AlterColumn("dbo.UserAccounts", "LasttName", c => c.String());
            AlterColumn("dbo.UserAccounts", "Email", c => c.String());
            AlterColumn("dbo.UserAccounts", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAccounts", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.UserAccounts", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.UserAccounts", "LasttName", c => c.String(nullable: false));
            AlterColumn("dbo.UserAccounts", "FirstName", c => c.String(nullable: false));
        }
    }
}
