using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}