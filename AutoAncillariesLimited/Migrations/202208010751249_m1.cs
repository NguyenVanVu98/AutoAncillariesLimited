namespace AutoAncillariesLimited.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarBrands",
                c => new
                    {
                        CarBrandId = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.CarBrandId);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        PartId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CarBrandId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CarName = c.String(),
                        UnitPrice = c.Single(nullable: false),
                        Description = c.String(nullable: false),
                        Conditon = c.String(),
                        Image = c.String(),
                        Image1 = c.String(),
                        Image2 = c.String(),
                        QtyInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartId)
                .ForeignKey("dbo.CarBrands", t => t.CarBrandId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.CarBrandId)
                .Index(t => t.SupplierId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(nullable: false),
                        ImgUrl = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ManufacturerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.PartId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        Amount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parts", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.OrderDetails", "PartId", "dbo.Parts");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Parts", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Parts", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Parts", "CarBrandId", "dbo.CarBrands");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderDetails", new[] { "PartId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Parts", new[] { "CategoryId" });
            DropIndex("dbo.Parts", new[] { "ManufacturerId" });
            DropIndex("dbo.Parts", new[] { "SupplierId" });
            DropIndex("dbo.Parts", new[] { "CarBrandId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Categories");
            DropTable("dbo.Parts");
            DropTable("dbo.CarBrands");
        }
    }
}
