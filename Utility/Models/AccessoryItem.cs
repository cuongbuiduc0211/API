using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Models
{
    public class AccessoryItem
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string  BrandName { get; set; }
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        public string Image { get; set; }
    }
}
