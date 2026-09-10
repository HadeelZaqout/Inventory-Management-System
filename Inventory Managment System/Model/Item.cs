using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Managment_System.Model
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Details { get; set; }
        public double Price { get; set; }
        public string MeasuringUnit { get; set; }
        public double ReOrderLevel { get; set; } = 10;
        [NotMapped]
        public double StockValue { get; set; }
    }
}
