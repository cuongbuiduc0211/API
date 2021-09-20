using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseAccess.Entities
{
    public partial class Brand
    {
        public Brand()
        {
            Accessories = new HashSet<Accessory>();
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Accessory> Accessories { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
