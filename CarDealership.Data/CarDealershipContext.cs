namespace CarDealership.Data
{
    using Models.Models;
    using System.Data.Entity;

    public class CarDealershipContext : DbContext
    {
        public CarDealershipContext()
            : base("name=CarDealershipContext")
        {
        }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<CarPhoto> CarPhotos { get; set; }
    }
}