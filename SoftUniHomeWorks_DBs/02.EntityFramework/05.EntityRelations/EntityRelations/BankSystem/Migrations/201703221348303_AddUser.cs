namespace BankSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BankAccounts", "User_Id", c => c.Int());
            CreateIndex("dbo.BankAccounts", "User_Id");
            AddForeignKey("dbo.BankAccounts", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankAccounts", "User_Id", "dbo.Users");
            DropIndex("dbo.BankAccounts", new[] { "User_Id" });
            DropColumn("dbo.BankAccounts", "User_Id");
            DropTable("dbo.Users");
        }
    }
}
