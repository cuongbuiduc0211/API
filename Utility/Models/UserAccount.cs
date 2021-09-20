
using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Models
{
    
    public class UserAccount
    {
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}
