namespace AfricanMagic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        CustomerFName = c.String(nullable: false, maxLength: 16, storeType: "nvarchar"),
                        CustomerLName = c.String(nullable: false, maxLength: 16, storeType: "nvarchar"),
                        Email = c.String(nullable: false, unicode: false),
                        ShippingAddress = c.String(nullable: false, unicode: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        ItemID = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ItemName = c.String(nullable: false, unicode: false),
                        Category = c.String(nullable: false, unicode: false),
                        Colour = c.String(nullable: false, unicode: false),
                        Size = c.String(nullable: false, unicode: false),
                        ItemPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SalesID = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        FinalAmount = c.Double(nullable: false),
                        DateOfPurchase = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.SalesID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sales");
            DropTable("dbo.Inventories");
            DropTable("dbo.Customers");
        }
    }
}
