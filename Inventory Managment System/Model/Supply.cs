using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Managment_System.Model
{
    public class Supply
    {
        [Key]
        public int SupplyId { get; set; }
        [Required]
        public int SupplierId { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<SupplyDetail> SupplyDetails { get; set; }

    }
}
