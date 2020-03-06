namespace OnlineMobileShop.Respository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        PhoneNumber = c.Long(nullable: false),
                        Gender = c.String(nullable: false),
                        MailID = c.String(nullable: false, maxLength: 35),
                        Password = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.UserID)
                .Index(t => t.MailID, unique: true);
            
            CreateTable(
                "dbo.Mobiles",
                c => new
                    {
                        MobileID = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Model = c.String(),
                        Battery = c.Int(nullable: false),
                        RAM = c.Int(nullable: false),
                        ROM = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MobileID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Accounts", new[] { "MailID" });
            DropTable("dbo.Mobiles");
            DropTable("dbo.Accounts");
        }
    }
}
