using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Managment_System.Model
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
