namespace CarDealership.Models.Models
{
    public class CarPhoto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] Photo { get; set; }
        public Car Car { get; set; }
    }
}
