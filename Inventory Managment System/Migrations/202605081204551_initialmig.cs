namespace Inventory_Managment_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Details = c.String(maxLength: 300),
                        Price = c.Double(nullable: false),
                        MeasuringUnit = c.String(),
                        ReOrderLevel = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Items");
        }
    }
}
