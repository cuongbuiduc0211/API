using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseAccess.Entities
{
    public partial class Accessory
    {
        public Accessory()
        {
            CarAccessories = new HashSet<CarAccessory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<CarAccessory> CarAccessories { get; set; }
    }
}
