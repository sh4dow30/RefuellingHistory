namespace Sh4dow.RefuellingHistory.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Manufacturer = c.String(),
                        Model = c.String(),
                        Year = c.DateTime(nullable: false),
                        Image = c.Binary(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Refuellings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        Mileage = c.Int(nullable: false),
                        FuelAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cost = c.Decimal(nullable: false, storeType: "money"),
                        Date = c.DateTime(nullable: false),
                        IsFullRefuelling = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cars", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Refuellings", "CarID", "dbo.Cars");
            DropIndex("dbo.Refuellings", new[] { "CarID" });
            DropIndex("dbo.Cars", new[] { "User_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.Refuellings");
            DropTable("dbo.Cars");
        }
    }
}
