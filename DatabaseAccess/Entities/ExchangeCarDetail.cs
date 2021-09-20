using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseAccess.Entities
{
    public partial class ExchangeCarDetail
    {
        public int Id { get; set; }
        public int ExchangeCarId { get; set; }
        public int BrandId { get; set; }
        public int CarId { get; set; }
        public int YearOfManufactor { get; set; }
        public string Origin { get; set; }
        public string LicensePlate { get; set; }
        public bool IsUsed { get; set; }
        public double Kilometers { get; set; }
        public int YearOfUsed { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }

        public virtual ExchangeCar ExchangeCar { get; set; }
    }
}
