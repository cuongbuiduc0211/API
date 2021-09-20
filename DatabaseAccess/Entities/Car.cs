using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseAccess.Entities
{
    public partial class Car
    {
        public Car()
        {
            CarAccessories = new HashSet<CarAccessory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string Despcription { get; set; }
        public int YearOfManufactor { get; set; }
        public int Price { get; set; }
        public string BodyType { get; set; }
        public string Origin { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Displacement { get; set; }
        public string EngineType { get; set; }
        public double? MaxPower { get; set; }
        public double? MaxTorque { get; set; }
        public double? GroundClearance { get; set; }
        public double? TurningRadius { get; set; }
        public double? FuelConsumption { get; set; }
        public string GearBox { get; set; }
        public int? Seats { get; set; }
        public double? KerbWeight { get; set; }
        public double? FuelCapacity { get; set; }
        public string WheelSize { get; set; }
        public string TyreSize { get; set; }
        public string FrontSuspension { get; set; }
        public string RearSuspension { get; set; }
        public string InteriorMaterial { get; set; }
        public string HeadLights { get; set; }
        public string TailLights { get; set; }
        public string FogLamps { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<CarAccessory> CarAccessories { get; set; }
    }
}
