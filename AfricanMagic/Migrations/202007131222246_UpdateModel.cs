namespace AfricanMagic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        CustomerFName = c.String(nullable: false, maxLength: 16, storeType: "nvarchar"),
                        CustomerLName = c.String(nullable: false, maxLength: 16, storeType: "nvarchar"),
                        ShippingAddress = c.String(nullable: false, unicode: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SalesID = c.Int(nullable: false, identity: true),
                        CustomerID = c.String(maxLength: 128, storeType: "nvarchar"),
                        ItemID = c.Int(nullable: false),
                        FinalAmount = c.Double(nullable: false),
                        DateOfPurchase = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.SalesID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.Inventories", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false, unicode: false),
                        ItemDescription = c.String(nullable: false, unicode: false),
                        Category = c.String(nullable: false, unicode: false),
                        Colour = c.String(nullable: false, unicode: false),
                        Size = c.String(nullable: false, unicode: false),
                        ItemPrice = c.Double(nullable: false),
                        ItemImage = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "ItemID", "dbo.Inventories");
            DropForeignKey("dbo.Sales", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Sales", new[] { "ItemID" });
            DropIndex("dbo.Sales", new[] { "CustomerID" });
            DropTable("dbo.Inventories");
            DropTable("dbo.Sales");
            DropTable("dbo.Customers");
        }
    }
}
