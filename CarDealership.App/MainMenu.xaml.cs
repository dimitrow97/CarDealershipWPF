using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Text.RegularExpressions;

namespace CarDealership.App
{  
    public partial class MainMenu : Window
    {
        public MainMenu()
        {            
            InitializeComponent();
            if(MainWindow.isOwner == false)
            {
                PlaceOrder.Visibility = Visibility.Visible;
                MyOrders.Visibility = Visibility.Visible;
            }
            else
            {
                AddNewCar.Visibility = Visibility.Visible;
                CheckOrders.Visibility = Visibility.Visible;
            }

            string[] brandsFile = File.ReadAllLines("CarBrands.txt");

            comboBoxMake.SelectedIndex = 0;

            foreach (var line in brandsFile)
            {
                string[] brand = line.Split(' ');
                comboBoxMake.Items.Add(brand[0]);
            }
            comboBoxModel.IsEnabled = false;


            comboBoxEndYear.IsEnabled = false;
            comboBoxStartYear.Items.Add("Any");
            comboBoxStartYear.SelectedIndex = 0;

            comboBoxRegDate.Items.Add("Any");
            comboBoxRegDate.SelectedIndex = 0;

            for (int i = 2017; i >= 1950; i--)
            {
                comboBoxStartYear.Items.Add("from " + i);
                comboBoxRegDate.Items.Add(i);
            }

            comboBoxTrans.Items.Add("Any");
            comboBoxTrans.SelectedIndex=0;
            comboBoxTrans.Items.Add("Manual Gearbox");
            comboBoxTrans.Items.Add("Semi-Automatic");
            comboBoxTrans.Items.Add("Automatic Transmission");

            comboBoxFuel.Items.Add("Any");
            comboBoxFuel.SelectedIndex = 0;
            comboBoxFuel.Items.Add("Petrol");
            comboBoxFuel.Items.Add("Diesel");
            comboBoxFuel.Items.Add("Electric");
            comboBoxFuel.Items.Add("Hybrid");


        }

        private void ShowCars_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Integrated security=true");
            string showCarsQuery = @"USE CarDealership SELECT Make, Model, ProductionYear AS [Production Year], Price, BodyPaint AS Color, KmPassed AS [Km Passed] FROM Cars";
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
            OrderGrid.Visibility = Visibility.Visible;

        }

        private void MyOrders_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddNewCar_Click(object sender, RoutedEventArgs e)
        {
         

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

         else  if (comboBoxMake.SelectedItem.ToString() == "BMW")
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
            if (comboBoxStartYear.SelectedItem != null && comboBoxStartYear.SelectedItem.ToString()!="Any")
            {
                comboBoxEndYear.IsEnabled = true;
               var omfg = comboBoxStartYear.SelectedItem.ToString();
                var resultString = Regex.Match(omfg, @"\d+").Value;

                comboBoxEndYear.Items.Clear();

                for (int y = 2017; y >= int.Parse(resultString) ; y--)
                      {
                        
                        comboBoxEndYear.Items.Add("to "+y);
                      }
                

            }
            if (comboBoxStartYear.SelectedIndex==0)
            {
                comboBoxEndYear.Items.Clear();
                comboBoxEndYear.IsEnabled = false;
            }
      }

  
        private void textBoxPriceFrom_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxPriceFrom.Clear();
        }

        private void textBoxPriceFrom_LostFocus(object sender, RoutedEventArgs e)
        {
            textBoxPriceFrom.Text = "from";
        }

        private void textBoxPriceTo_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxPriceTo.Clear();
        }

        private void textBoxPriceTo_LostFocus(object sender, RoutedEventArgs e)
        {
            textBoxPriceTo.Text = "to";
        }
    }
}
