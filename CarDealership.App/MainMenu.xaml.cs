using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;
using System;
using CarDealership.Data;
using CarDealership.Models.Models;
using System.Linq;
using System.Collections.Generic;

namespace CarDealership.App
{
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            if (MainWindow.isOwner == false)
            {
                PlaceOrder.Visibility = Visibility.Visible;
                MyOrders.Visibility = Visibility.Visible;
            }
            else
            {
                AddNewCar.Visibility = Visibility.Visible;
                CheckOrders.Visibility = Visibility.Visible;
            }
        }

        private void ShowCars_Click(object sender, RoutedEventArgs e)
        {
            OrderGrid.Visibility = Visibility.Hidden;
            AddNewCarGrid.Visibility = Visibility.Hidden;
            dataGrid1.Visibility = Visibility.Hidden;
            dataGrid.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Hidden;
            button1.Visibility = Visibility.Hidden;            

            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Integrated security=true");
            string showCarsQuery = @"USE CarDealership SELECT Id, Make, Model, ProductionYear AS [Production Year], Price, BodyPaint AS Color, KmPassed AS [Km Passed] FROM Cars";
            SqlCommand showCars = new SqlCommand(showCarsQuery, conn);
            conn.Open();
            SqlDataAdapter datAdapter = new SqlDataAdapter();
            datAdapter.SelectCommand = showCars;
            DataTable cars = new DataTable();
            datAdapter.Fill(cars);
            dataGrid.DataContext = cars.DefaultView;
            conn.Close();
        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            dataGrid1.Visibility = Visibility.Hidden;           
            dataGrid.Visibility = Visibility.Hidden;
            OrderGrid.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Hidden;
            button1.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;
            FullInfo.IsEnabled = false;
        }

        private void MyOrders_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.Visibility = Visibility.Hidden;
            OrderGrid.Visibility = Visibility.Hidden;
            dataGrid1.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Hidden;
            button1.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;
            FullInfo.IsEnabled = false;

            CarDealershipContext context = new CarDealershipContext();
            var customerId = context.Customers.Where(x => x.Username == MainWindow.username).Select(x => x.Id).FirstOrDefault();
            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Integrated security=true");
            string showOrdersQuery = $@"USE CarDealership SELECT u.Id,
             Make , Model , ProductionYearStart AS [Production Year Start],
             ProductionYearEnd AS [Production Year End],
             PriceStart AS [Price Start],PriceEnd AS [Price End],
             BodyPaint AS Color,KmPassed AS [Km Passed],Transmission,Fuel,HorsePower AS [Horse Power],
             EngineDisplacement AS [Engine Displacement], CONCAT(o.FirstName,' ', o.LastName) AS [Taken By], o.PhoneNumber AS [Phone Number] FROM Orders AS u
			 LEFT JOIN Owners AS o
			 ON u.TakenBy_Id = o.Id
             WHERE OrderedBy_Id = {customerId}";
            SqlCommand showOrders = new SqlCommand(showOrdersQuery, conn);
            conn.Open();
            SqlDataAdapter datAdapter = new SqlDataAdapter();
            datAdapter.SelectCommand = showOrders;
            DataTable orders = new DataTable();
            datAdapter.Fill(orders);
            dataGrid1.DataContext = orders.DefaultView;
            conn.Close();
        }

        private void AddNewCar_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.Visibility = Visibility.Hidden;
            button.Visibility = Visibility.Hidden;
            button1.Visibility = Visibility.Hidden;
            dataGrid1.Visibility = Visibility.Hidden;
            AddNewCarGrid.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Hidden;
            FullInfo.IsEnabled = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.Visibility = Visibility.Hidden;
            OrderGrid.Visibility = Visibility.Hidden;
            dataGrid1.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Hidden;
            button1.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;
            FullInfo.IsEnabled = false;

            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Integrated security=true");
            string showOrdersQuery = @"USE CarDealership SELECT u.Id,
             Make , Model , ProductionYearStart AS [Production Year Start],
             ProductionYearEnd AS [Production Year End],
             PriceStart AS [Price Start],PriceEnd AS [Price End],
             BodyPaint AS Color,KmPassed AS [Km Passed],Transmission,Fuel,HorsePower AS [Horse Power],
             EngineDisplacement AS [Engine Displacement],CONCAT(o.FirstName,' ', o.LastName) AS [Taken By], o.PhoneNumber AS [Phone Number] FROM Orders AS u
			 LEFT JOIN Owners AS o
			 ON u.TakenBy_Id = o.Id";
            SqlCommand showOrders = new SqlCommand(showOrdersQuery, conn);
            conn.Open();
            SqlDataAdapter datAdapter = new SqlDataAdapter();
            datAdapter.SelectCommand = showOrders;
            DataTable orders = new DataTable();
            datAdapter.Fill(orders);
            dataGrid1.DataContext = orders.DefaultView;
            conn.Close();
        }

        private void comboBoxStartYear_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxEndYear.IsEnabled = false;
            comboBoxStartYear.Items.Add("Any");
            comboBoxStartYear.SelectedIndex = 0;

            for (int i = 2017; i >= 1950; i--)
            {
                comboBoxStartYear.Items.Add("from " + i);
            }
        }

        private void comboBoxMake_Loaded(object sender, RoutedEventArgs e)
        {
            string[] brandsFile = File.ReadAllLines("CarBrands.txt");

            comboBoxMake.SelectedIndex = 0;

            foreach (var line in brandsFile)
            {
                string[] brand = line.Split(' ');
                comboBoxMake.Items.Add(brand[0]);
            }
            comboBoxModel.IsEnabled = false;
        }

        private void comboBoxMake_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxMake.SelectedItem.ToString() == "Audi")
            {
                comboBoxModel.IsEnabled = true;
                comboBoxModel.Items.Clear();
                comboBoxModel.SelectedIndex = 0;
                string[] car = File.ReadAllLines("Audi.txt");
                foreach (var line in car)
                {
                    string[] x = line.Split(' ');
                    comboBoxModel.Items.Add(x[0]);
                }
            }

            else if (comboBoxMake.SelectedItem.ToString() == "BMW")
            {
                comboBoxModel.IsEnabled = true;
                comboBoxModel.Items.Clear();
                comboBoxModel.SelectedIndex = 0;
                string[] car = File.ReadAllLines("BMW.txt");
                foreach (var line in car)
                {
                    string[] x = line.Split(' ');
                    comboBoxModel.Items.Add(x[0]);
                }
            }

            else if (comboBoxMake.SelectedItem.ToString() == "Mercedes-Benz")
            {
                comboBoxModel.IsEnabled = true;
                comboBoxModel.Items.Clear();
                comboBoxModel.SelectedIndex = 0;
                string[] car = File.ReadAllLines("Mercedes-Benz.txt");
                foreach (var line in car)
                {
                    string[] x = line.Split(' ');
                    comboBoxModel.Items.Add(x[0]);
                }
            }

            else if (comboBoxMake.SelectedItem.ToString() == "Porsche")
            {
                comboBoxModel.IsEnabled = true;
                comboBoxModel.Items.Clear();
                comboBoxModel.SelectedIndex = 0;
                string[] car = File.ReadAllLines("Porsche.txt");
                foreach (var line in car)
                {
                    string[] x = line.Split(' ');
                    comboBoxModel.Items.Add(x[0]);
                }
            }

            else if (comboBoxMake.SelectedItem.ToString() == "Volkswagen")
            {
                comboBoxModel.IsEnabled = true;
                comboBoxModel.Items.Clear();
                comboBoxModel.SelectedIndex = 0;
                string[] car = File.ReadAllLines("Volkswagen.txt");
                foreach (var line in car)
                {
                    string[] x = line.Split(' ');
                    comboBoxModel.Items.Add(x[0]);
                }
            }

            else if (comboBoxMake.SelectedItem.ToString() == "Any")
            {
                comboBoxModel.Items.Clear();
                comboBoxModel.IsEnabled = false;
            }
        }

        private void comboBoxStartYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxStartYear.SelectedItem != null && comboBoxStartYear.SelectedItem.ToString() != "Any")
            {
                comboBoxEndYear.IsEnabled = true;
                var omfg = comboBoxStartYear.SelectedItem.ToString();
                var resultString = Regex.Match(omfg, @"\d+").Value;

                comboBoxEndYear.Items.Clear();
                comboBoxEndYear.Items.Add("Any");
                comboBoxEndYear.SelectedIndex = 0;
                for (int y = 2017; y >= int.Parse(resultString); y--)
                {
                    comboBoxEndYear.Items.Add("to " + y);
                }
            }

            if (comboBoxStartYear.SelectedIndex == 0)
            {
                comboBoxEndYear.Items.Clear();
                comboBoxEndYear.IsEnabled = false;
            }
        }

        private void FullInfo_Click(object sender, RoutedEventArgs e)
        {            
            if (dataGrid.SelectedIndex>-1)
            {
                CarFullInfo form = new CarFullInfo();
                form.Show();               
            }      
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainWindow.isOwner == true)
            {
                button2.Visibility = Visibility.Visible;
            }
            
            FullInfo.IsEnabled = true;
            try
            {
                var car = dataGrid.SelectedItem;
                string id = (dataGrid.SelectedCells[0].Column.GetCellContent(car) as TextBlock).Text;
                carId = int.Parse(id);
            }
            catch { }
          
        }
        public static int carId;

        private void comboBoxMakeANC_Loaded(object sender, RoutedEventArgs e)
        {
            string[] brandsFile = File.ReadAllLines("CarBrands.txt");

            comboBoxMakeANC.SelectedIndex = 0;

            foreach (var line in brandsFile)
            {
                string[] brand = line.Split(' ');
                comboBoxMakeANC.Items.Add(brand[0]);
            }
            comboBoxModelANC.IsEnabled = false;            
        }

        private void comboBoxMakeANC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxMakeANC.SelectedItem.ToString() == "Audi")
            {
                comboBoxModelANC.IsEnabled = true;
                comboBoxModelANC.Items.Clear();
                comboBoxModelANC.SelectedIndex = 0;
                string[] car = File.ReadAllLines("Audi.txt");
                foreach (var line in car)
                {
                    string[] x = line.Split(' ');
                    comboBoxModelANC.Items.Add(x[0]);
                }
            }

            else if (comboBoxMakeANC.SelectedItem.ToString() == "BMW")
            {
                comboBoxModelANC.IsEnabled = true;
                comboBoxModelANC.Items.Clear();
                comboBoxModelANC.SelectedIndex = 0;
                string[] car = File.ReadAllLines("BMW.txt");
                foreach (var line in car)
                {
                    string[] x = line.Split(' ');
                    comboBoxModelANC.Items.Add(x[0]);
                }
            }

            else if (comboBoxMakeANC.SelectedItem.ToString() == "Mercedes-Benz")
            {
                comboBoxModelANC.IsEnabled = true;
                comboBoxModelANC.Items.Clear();
                comboBoxModelANC.SelectedIndex = 0;
                string[] car = File.ReadAllLines("Mercedes-Benz.txt");
                foreach (var line in car)
                {
                    string[] x = line.Split(' ');
                    comboBoxModelANC.Items.Add(x[0]);
                }
            }

            else if (comboBoxMakeANC.SelectedItem.ToString() == "Porsche")
            {
                comboBoxModelANC.IsEnabled = true;
                comboBoxModelANC.Items.Clear();
                comboBoxModelANC.SelectedIndex = 0;
                string[] car = File.ReadAllLines("Porsche.txt");
                foreach (var line in car)
                {
                    string[] x = line.Split(' ');
                    comboBoxModelANC.Items.Add(x[0]);
                }
            }

            else if (comboBoxMakeANC.SelectedItem.ToString() == "Volkswagen")
            {
                comboBoxModelANC.IsEnabled = true;
                comboBoxModelANC.Items.Clear();
                comboBoxModelANC.SelectedIndex = 0;
                string[] car = File.ReadAllLines("Volkswagen.txt");
                foreach (var line in car)
                {
                    string[] x = line.Split(' ');
                    comboBoxModelANC.Items.Add(x[0]);
                }
            }


            else if (comboBoxMakeANC.SelectedItem.ToString() == "Any")
            {
                comboBoxModelANC.Items.Clear();
                comboBoxModelANC.IsEnabled = false;
            }
        }

        private void comboBoxTrans_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxTrans.Items.Add("Any");
            comboBoxTrans.SelectedIndex = 0;
            comboBoxTrans.Items.Add("Manual Gearbox");
            comboBoxTrans.Items.Add("Semi-Automatic");
            comboBoxTrans.Items.Add("Automatic Transmission");
        }

        private void comboBoxTransANC_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxTransANC.Items.Add("Any");
            comboBoxTransANC.SelectedIndex = 0;
            comboBoxTransANC.Items.Add("Manual Gearbox");
            comboBoxTransANC.Items.Add("Semi-Automatic");
            comboBoxTransANC.Items.Add("Automatic Transmission");
        }

        private void comboBoxFuel_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxFuel.Items.Add("Any");
            comboBoxFuel.SelectedIndex = 0;
            comboBoxFuel.Items.Add("Petrol");
            comboBoxFuel.Items.Add("Diesel");
            comboBoxFuel.Items.Add("Electric");
            comboBoxFuel.Items.Add("Hybrid");
        }

        private void comboBoxFuelANC_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxFuelANC.Items.Add("Any");
            comboBoxFuelANC.SelectedIndex = 0;
            comboBoxFuelANC.Items.Add("Petrol");
            comboBoxFuelANC.Items.Add("Diesel");
            comboBoxFuelANC.Items.Add("Electric");
            comboBoxFuelANC.Items.Add("Hybrid");
        }

        private void comboBoxYearMadeANC_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxYearMadeANC.Items.Add("Any");
            comboBoxYearMadeANC.SelectedIndex = 0;

            for (int i = 2017; i >= 1950; i--)
            {
                comboBoxYearMadeANC.Items.Add(i);
            }
        }

   
        private void buttonResetANC_Click(object sender, RoutedEventArgs e)
        {
            comboBoxMakeANC.SelectedIndex = 0;
            comboBoxTransANC.SelectedIndex = 0;
            comboBoxFuelANC.SelectedIndex = 0;
            comboBoxYearMadeANC.SelectedIndex = 0;
            textBoxPriceANC.Clear();
            textBoxColourANC.Clear();
            textBoxHpANC.Clear();
            textBoxCcANC.Clear();
            textBoxKmANC.Clear();
            textBoxDescription.Clear();
            picCount.Visibility = Visibility.Hidden;           
            label27.Visibility = Visibility.Hidden;
            image.Visibility = Visibility.Hidden;
            photos.Clear();
        }
        List<string> photos = new List<string>();
        private void buttonAddImage_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new Microsoft.Win32.OpenFileDialog() { Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|GIF Files (*.gif)|*.gif" };
            var result = ofd.ShowDialog();
            if (result == false) return;
            string path = ofd.FileName;
            image.Source = new BitmapImage(new Uri(path));
            photos.Add(path);
            picCount.Content = photos.Count();
          
            label27.Visibility = Visibility.Visible;
            picCount.Visibility = Visibility.Visible;
            image.Visibility = Visibility.Visible;
        }

        private void buttonResetOrder_Click(object sender, RoutedEventArgs e)
        {
            comboBoxMake.SelectedIndex = 0;
            comboBoxStartYear.SelectedIndex = 0;
            comboBoxTrans.SelectedIndex = 0;
            comboBoxFuel.SelectedIndex = 0;
            textBoxColour.Clear();
            textBoxHP.Clear();
            textBoxCC.Clear();
            textBoxKm.Clear();
            textBoxPriceFrom.Clear();
            textBoxPriceTo.Clear();
        }

        private void buttonSubmitANC_Click(object sender, RoutedEventArgs e)
        {          
            CarDealershipContext context = new CarDealershipContext();
            var seller = context.Owners.Where(x => x.Username == MainWindow.username).FirstOrDefault();
            int count = context.Cars.Count();
            try
            {
                Car newCar = new Car()
                {
                    Make = comboBoxMakeANC.Text,
                    Model = comboBoxModelANC.Text,
                    ProductionYear = comboBoxYearMadeANC.Text,
                    Fuel = comboBoxFuelANC.Text,
                    Transmission = comboBoxTransANC.Text,
                    BodyPaint = textBoxColourANC.Text,
                    KmPassed = long.Parse(textBoxKmANC.Text),
                    Description = textBoxDescription.Text,
                    EngineDisplacement = int.Parse(textBoxCcANC.Text),
                    HorsePower = int.Parse(textBoxHpANC.Text),
                    Price = int.Parse(textBoxPriceANC.Text),
                    Seller = seller
                };
                seller.CarsForSale.Add(newCar);
                context.Cars.Add(newCar);

                for (int i = 0; i < photos.Count(); i++)
                {
                    CarPhoto photo = new CarPhoto()
                    {
                        FileName = comboBoxMakeANC.Text + comboBoxModelANC.Text + "Car" + count + "." + (i + 1),
                        Photo = imageToByteArray(new BitmapImage(new Uri(photos[i]))),
                        Car = newCar
                    };
                    newCar.Photos.Add(photo);
                }
                context.SaveChanges();
                MessageBox.Show("Successfully Added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                comboBoxMakeANC.SelectedIndex = 0;
                comboBoxTransANC.SelectedIndex = 0;
                comboBoxFuelANC.SelectedIndex = 0;
                comboBoxYearMadeANC.SelectedIndex = 0;
                textBoxPriceANC.Clear();
                textBoxColourANC.Clear();
                textBoxHpANC.Clear();
                textBoxCcANC.Clear();
                textBoxKmANC.Clear();
                textBoxDescription.Clear();
                picCount.Visibility = Visibility.Hidden;
                label27.Visibility = Visibility.Hidden;
                image.Visibility = Visibility.Hidden;
                photos.Clear();

            }
            catch (Exception)
            {

               MessageBox.Show("Please fill all the fields !");
            }
           
        }

        public byte[] imageToByteArray(BitmapImage imageIn)
        {
            MemoryStream memoryStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageIn));
            encoder.Save(memoryStream);
            return memoryStream.ToArray();
        }

        private void buttonSubmitOrder_Click(object sender, RoutedEventArgs e)
        {
            CarDealershipContext context = new CarDealershipContext();

            var OrderByCustomer = context.Customers.Where(x => x.Username == MainWindow.username).FirstOrDefault();
            try
            {
                Order newOrder = new Order()
                {
                    Make = comboBoxMake.Text,
                    Model = comboBoxModel.Text,
                    ProductionYearStart = Regex.Match(comboBoxStartYear.SelectedItem.ToString(), @"\d+").Value,
                    ProductionYearEnd = Regex.Match(comboBoxEndYear.SelectedItem.ToString(), @"\d+").Value,
                    PriceStart = int.Parse(textBoxPriceFrom.Text),
                    PriceEnd = int.Parse(textBoxPriceTo.Text),
                    BodyPaint = textBoxColour.Text,
                    KmPassed = long.Parse(textBoxKm.Text),
                    Transmission = comboBoxTrans.Text,
                    Fuel = comboBoxFuel.Text,
                    HorsePower = int.Parse(textBoxHP.Text),
                    EngineDisplacement = int.Parse(textBoxCC.Text),
                    OrderPlacedOn = DateTime.Now,
                    OrderedBy = OrderByCustomer
                };

                context.Orders.Add(newOrder);
                context.SaveChanges();
                MessageBox.Show("Successfully Added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                comboBoxMake.SelectedIndex = 0;
                comboBoxStartYear.SelectedIndex = 0;
                comboBoxTrans.SelectedIndex = 0;
                comboBoxFuel.SelectedIndex = 0;
                textBoxColour.Clear();
                textBoxHP.Clear();
                textBoxCC.Clear();
                textBoxKm.Clear();
                textBoxPriceFrom.Clear();
                textBoxPriceTo.Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("Please fill all the fields !");
            }
          
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            CarDealershipContext context = new CarDealershipContext();
            var owner = context.Owners.Where(x => x.Username == MainWindow.username).FirstOrDefault();
            var order = context.Orders.Where(y => y.Id == orderId).FirstOrDefault();
            order.TakenBy = owner;
            context.SaveChanges();
            MessageBox.Show("You've successfully taken the order", "Success!", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Integrated security=true");
            string showOrdersQuery = @"USE CarDealership SELECT u.Id,
             Make , Model , ProductionYearStart AS [Production Year Start],
             ProductionYearEnd AS [Production Year End],
             PriceStart AS [Price Start],PriceEnd AS [Price End],
             BodyPaint AS Color,KmPassed AS [Km Passed],Transmission,Fuel,HorsePower AS [Horse Power],
             EngineDisplacement AS [Engine Displacement],CONCAT(o.FirstName,' ', o.LastName) AS [Taken By], o.PhoneNumber AS [Phone Number] FROM Orders AS u
			 LEFT JOIN Owners AS o
			 ON u.TakenBy_Id = o.Id";
            SqlCommand showOrders = new SqlCommand(showOrdersQuery, conn);
            conn.Open();
            SqlDataAdapter datAdapter = new SqlDataAdapter();
            datAdapter.SelectCommand = showOrders;
            DataTable orders = new DataTable();
            datAdapter.Fill(orders);
            dataGrid1.DataContext = orders.DefaultView;
            conn.Close();

           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            CarDealershipContext context = new CarDealershipContext();            
            var order = context.Orders.Where(y => y.Id == orderId).FirstOrDefault();
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Removing order", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
                MessageBox.Show("Successfully removed!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
            if (MainWindow.isOwner == false)
            {
                var customerId = context.Customers.Where(x => x.Username == MainWindow.username).Select(x => x.Id).FirstOrDefault();
                SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Integrated security=true");
                string showOrdersQuery = $@"USE CarDealership SELECT u.Id,
             Make , Model , ProductionYearStart AS [Production Year Start],
             ProductionYearEnd AS [Production Year End],
             PriceStart AS [Price Start],PriceEnd AS [Price End],
             BodyPaint AS Color,KmPassed AS [Km Passed],Transmission,Fuel,HorsePower AS [Horse Power],
             EngineDisplacement AS [Engine Displacement], CONCAT(o.FirstName,' ', o.LastName) AS [Taken By], o.PhoneNumber AS [Phone Number] FROM Orders AS u
			 LEFT JOIN Owners AS o
			 ON u.TakenBy_Id = o.Id
             WHERE OrderedBy_Id = {customerId}";
                SqlCommand showOrders = new SqlCommand(showOrdersQuery, conn);
                conn.Open();
                SqlDataAdapter datAdapter = new SqlDataAdapter();
                datAdapter.SelectCommand = showOrders;
                DataTable orders = new DataTable();
                datAdapter.Fill(orders);
                dataGrid1.DataContext = orders.DefaultView;
                conn.Close();
            }
            else
            {
                SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Integrated security=true");
                string showOrdersQuery = @"USE CarDealership SELECT u.Id,
             Make , Model , ProductionYearStart AS [Production Year Start],
             ProductionYearEnd AS [Production Year End],
             PriceStart AS [Price Start],PriceEnd AS [Price End],
             BodyPaint AS Color,KmPassed AS [Km Passed],Transmission,Fuel,HorsePower AS [Horse Power],
             EngineDisplacement AS [Engine Displacement],CONCAT(o.FirstName,' ', o.LastName) AS [Taken By], o.PhoneNumber AS [Phone Number] FROM Orders AS u
			 LEFT JOIN Owners AS o
			 ON u.TakenBy_Id = o.Id";
                SqlCommand showOrders = new SqlCommand(showOrdersQuery, conn);
                conn.Open();
                SqlDataAdapter datAdapter = new SqlDataAdapter();
                datAdapter.SelectCommand = showOrders;
                DataTable orders = new DataTable();
                datAdapter.Fill(orders);
                dataGrid1.DataContext = orders.DefaultView;
                conn.Close();
            }
        }
        public static int orderId;
        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainWindow.isOwner == false)
            {
                button.Visibility = Visibility.Hidden;
                button1.Visibility = Visibility.Visible;
            }
            else
            {
                button.Visibility = Visibility.Visible;
                button1.Visibility = Visibility.Visible;
            }

            try
            {
                var order = dataGrid1.SelectedItem;
                string id = (dataGrid1.SelectedCells[0].Column.GetCellContent(order) as TextBlock).Text;
                orderId = int.Parse(id);
            }
            catch { }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            CarDealershipContext context = new CarDealershipContext();
            var car = context.Cars.Where(y => y.Id == carId).FirstOrDefault();
            var carPhotos = context.CarPhotos.Where(y => y.Car.Id == car.Id).ToList();
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Removing Car", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                foreach(var photo in carPhotos)
                {
                    context.CarPhotos.Remove(photo);
                }
                context.Cars.Remove(car);
                context.SaveChanges();
                MessageBox.Show("Successfully removed!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Integrated security=true");
            string showCarsQuery = @"USE CarDealership SELECT Id, Make, Model, ProductionYear AS [Production Year], Price, BodyPaint AS Color, KmPassed AS [Km Passed] FROM Cars";
            SqlCommand showCars = new SqlCommand(showCarsQuery, conn);
            conn.Open();
            SqlDataAdapter datAdapter = new SqlDataAdapter();
            datAdapter.SelectCommand = showCars;
            DataTable cars = new DataTable();
            datAdapter.Fill(cars);
            dataGrid.DataContext = cars.DefaultView;
            conn.Close();
        }
    }
}
