using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Managment_System.Model
{
    public class Invoice
    {
        [Key] 
        public int InvoiceId { get; set; }
        [Required] 
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public double ExtraCharges { get; set; }
        public double Discount { get; set; }
        public double PaidAmount { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<InvoiceItem> Invoiceitems { get; set; }
    }
}
