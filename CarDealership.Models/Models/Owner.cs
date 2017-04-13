using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.Models
{
    public class Owner
    {
        public Owner()
        {
            this.CarsForSale = new HashSet<Car>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastNme { get; set; }        
        public string PhoneNumber { get; set; }
        public virtual ICollection<Car> CarsForSale { get; set; }        
    }
}
