using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Managment_System.Model
{
    public class InventoryDBContext :DbContext
    {
        public InventoryDBContext() : base("ConStr")
        { }
        public DbSet<Item> Items { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<SupplyDetail> SupplyDetails { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>()
            .HasRequired(s => s.Item)
            .WithMany()
            .HasForeignKey(s => s.ItemId)
            .WillCascadeOnDelete(false);
            modelBuilder.Entity<Stock>()
            .HasRequired(s => s.SupplyDetail)
            .WithMany()
            .HasForeignKey(sd => sd.SupplyDetailId)
            .WillCascadeOnDelete(false);
            modelBuilder.Entity<SupplyDetail>()
            .HasRequired(s => s.Item)
            .WithMany()
            .HasForeignKey(i => i.ItemId)
            .WillCascadeOnDelete(false);
            modelBuilder.Entity<SupplyDetail>()
            .HasRequired(s => s.Supply)
            .WithMany()
            .HasForeignKey(s=>s.SupplyId)
            .WillCascadeOnDelete(false);
            modelBuilder.Entity<Supply>()
            .HasRequired(s => s.Supplier)
            .WithMany()
            .HasForeignKey(sp =>sp.SupplierId)
            .WillCascadeOnDelete(false);
            modelBuilder.Entity<Invoice>()
             .HasRequired(i => i.Customer)
             .WithMany()
             .HasForeignKey(c => c.CustomerId)
             .WillCascadeOnDelete (false);

            modelBuilder.Entity<InvoiceItem>()
                .HasRequired(i => i.Invoice)
                .WithMany()
                .HasForeignKey(i => i.InvoiceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InvoiceItem>()
                .HasRequired(i => i.Item)
                .WithMany()
                .HasForeignKey(i => i.ItemId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
