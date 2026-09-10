using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Managment_System.Model
{
    public class Stock
    {
        [Key] 
        public int StockId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int SupplyDetailId { get; set; }
        [Required]
        public double StockValue { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
        [ForeignKey("SupplyDetailId")]
        public virtual SupplyDetail SupplyDetail { get; set; }
    }
}
