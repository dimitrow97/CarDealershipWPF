using System;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Make { get; set; }
        [MaxLength(50)]
        public string Model { get; set; }
        [MaxLength(11)]
        public string ProductionYearStart { get; set; }
        [MaxLength(11)]
        public string ProductionYearEnd { get; set; }
        public int? PriceStart { get; set; }
        public int? PriceEnd { get; set; }
        [MaxLength(30)]
        public string BodyPaint { get; set; }
        public long? KmPassed { get; set; }
        [MaxLength(50)]
        public string Transmission { get; set; }
        [MaxLength(20)]
        public string Fuel { get; set; }
        public int? HorsePower { get; set; }
        public int? EngineDisplacement { get; set; }
        public DateTime OrderPlacedOn { get; set; }   
        public Customer OrderedBy { get; set; }
        public Owner TakenBy { get; set; }
    }
}
