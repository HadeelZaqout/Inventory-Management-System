using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Managment_System.Model
{
    public class User
    {
        [Key]
        [Required]
        [StringLength(20)]
        public String UserName { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
        public int PremissionLevel { get; set; } = 0;
    }
}
