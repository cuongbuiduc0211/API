using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Models
{
    public class SelfProfile
    {
        [EmailAddress]
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Image { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Address { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? Status { get; set; }
        public int? ExchangePost { get; set; }
    }
}
