using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Make { get; set; }
        [MaxLength(50)]
        public string Model { get; set; }
        [MaxLength(11)]
        public string ProductionYear { get; set; }
        public int Price { get; set; }
        [MaxLength(30)]
        public string BodyPaint { get; set; }
        public long KmPassed { get; set; }
        [MaxLength(11)]
        public string YearFirstReg { get; set; }
        [MaxLength(20)]
        public string Transmission { get; set; }
        [MaxLength(25)]
        public string Fuel { get; set; }
        public int HorsePower { get; set; }
        public int EngineDisplacement { get; set; }
        public string Description { get; set; }  
        public Owner Seller { get; set; }     
    }
}
