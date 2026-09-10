namespace Inventory_Managment_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Supplier : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        StockId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        SupplyDetailId = c.Int(nullable: false),
                        StockValue = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.StockId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.SupplyDetails", t => t.SupplyDetailId)
                .Index(t => t.ItemId)
                .Index(t => t.SupplyDetailId);
            
            CreateTable(
                "dbo.SupplyDetails",
                c => new
                    {
                        SupplyDetailId = c.Int(nullable: false, identity: true),
                        SupplyId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        PurchasePrice = c.Double(nullable: false),
                        Quantity = c.Double(nullable: false),
                        Supply_SupplyId = c.Int(),
                    })
                .PrimaryKey(t => t.SupplyDetailId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Supplies", t => t.Supply_SupplyId)
                .ForeignKey("dbo.Supplies", t => t.SupplyId)
                .Index(t => t.SupplyId)
                .Index(t => t.ItemId)
                .Index(t => t.Supply_SupplyId);
            
            CreateTable(
                "dbo.Supplies",
                c => new
                    {
                        SupplyId = c.Int(nullable: false, identity: true),
                        SupplierId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SupplyId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Phone = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "SupplyDetailId", "dbo.SupplyDetails");
            DropForeignKey("dbo.SupplyDetails", "SupplyId", "dbo.Supplies");
            DropForeignKey("dbo.SupplyDetails", "Supply_SupplyId", "dbo.Supplies");
            DropForeignKey("dbo.Supplies", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.SupplyDetails", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Stocks", "ItemId", "dbo.Items");
            DropIndex("dbo.Supplies", new[] { "SupplierId" });
            DropIndex("dbo.SupplyDetails", new[] { "Supply_SupplyId" });
            DropIndex("dbo.SupplyDetails", new[] { "ItemId" });
            DropIndex("dbo.SupplyDetails", new[] { "SupplyId" });
            DropIndex("dbo.Stocks", new[] { "SupplyDetailId" });
            DropIndex("dbo.Stocks", new[] { "ItemId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Supplies");
            DropTable("dbo.SupplyDetails");
            DropTable("dbo.Stocks");
        }
    }
}
