using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Managment_System.Model
{
    public class InvoiceItem
    {
        [Key] 
        public int InvoiceItemId { get; set; }
        [Required]
        public int InvoiceId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public double SalePrice { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

    }
}
