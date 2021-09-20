using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Models
{
    public class CarItem
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string BrandName {get; set; }
        public string Despcription { get; set; }
        [Required]
        public int YearOfManufactor { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string BodyType { get; set; }
        [Required]
        public string Origin { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Displacement { get; set; }
        public string EngineType { get; set; }
        public double MaxPower { get; set; }
        public double MaxTorque { get; set; }
        public double GroundClearance { get; set; }
        public double TurningRadius { get; set; }
        public double FuelConsumption { get; set; }
        public string GearBox { get; set; }
        public int Seats { get; set; }
        public double KerbWeight { get; set; }
        public double FuelCapacity { get; set; }
        public string WheelSize { get; set; }
        public string TyreSize { get; set; }
        public string FrontSuspension { get; set; }
        public string RearSuspension { get; set; }
        public string InteriorMaterial { get; set; }
        public string HeadLights { get; set; }
        public string TailLights { get; set; }
        public string FogLamps { get; set; }
        public string Image { get; set; }
    }
}
