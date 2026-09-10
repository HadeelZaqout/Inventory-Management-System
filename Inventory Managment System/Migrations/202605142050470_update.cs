namespace Inventory_Managment_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "ExtraCharges", c => c.Double(nullable: false));
            AlterColumn("dbo.Invoices", "Discount", c => c.Double(nullable: false));
            AlterColumn("dbo.Invoices", "PaidAmount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "PaidAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Invoices", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Invoices", "ExtraCharges", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
