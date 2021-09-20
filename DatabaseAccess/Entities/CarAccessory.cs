using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseAccess.Entities
{
    public partial class CarAccessory
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        public int? AccessoryId { get; set; }

        public virtual Accessory Accessory { get; set; }
        public virtual Car Car { get; set; }
    }
}
