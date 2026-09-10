using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Managment_System.Model
{
    public class SupplyDetail
    {
        [Key]
        public int SupplyDetailId { get; set; }
        [Required]
        public int SupplyId  { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public double PurchasePrice { get; set; }
        [Required]
        public double Quantity  { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
        [ForeignKey("SupplyId")]
        public virtual Supply Supply { get; set; }

    }
}
