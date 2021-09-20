using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseAccess.Entities
{
    public partial class ExchangeAccessorryDetail
    {
        public int Id { get; set; }
        public int ExchangeAccessoryId { get; set; }
        public int AccessoryId { get; set; }
        public bool IsUsed { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }

        public virtual ExchangeAccessory ExchangeAccessory { get; set; }
    }
}
