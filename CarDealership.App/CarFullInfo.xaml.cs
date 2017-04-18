using CarDealership.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CarDealership.App
{
    public partial class CarFullInfo : Window
    {
        public CarFullInfo()
        {
            InitializeComponent();

            CarDealershipContext context = new CarDealershipContext();

            var car = context.Cars.Where(x => x.Id == MainMenu.carId).FirstOrDefault();
            var picturesCount = context.CarPhotos.Where(x => x.Car.Id == MainMenu.carId).Count();

            makeLabel.Content = car.Make;
            modelLabel.Content = car.Model;
            priceLabel.Content = car.Price + "€";
            yearLabel.Content = car.ProductionYear;
            colorLabel.Content = car.BodyPaint;
            fuelLabel.Content = car.Fuel;
            tranLabel.Content = car.Transmission;
            kmLabel.Content = car.KmPassed + "km";
            edLabel.Content = car.EngineDisplacement + "cm3";
            hpLabel.Content = car.HorsePower + "hp";
            desLabel.Content = "Description - " + car.Description;

            if (picturesCount > 0)
                button.IsEnabled = true;
            else errorLabel.Visibility = Visibility.Visible;
        }

        public static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        public static int count = 1;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            CarDealershipContext context = new CarDealershipContext();
            var pictures = context.CarPhotos.Where(x => x.Car.Id == MainMenu.carId).Select(i => i.Photo).ToList();
            var picturesCount = context.CarPhotos.Where(x => x.Car.Id == MainMenu.carId).Count();

            if (count < picturesCount)
            {                
                image.Source = LoadImage(pictures[count]);
                count++;
            }
            else
            {
                count = 0;
                image.Source = LoadImage(pictures[count]);
            }
        }
    }
}