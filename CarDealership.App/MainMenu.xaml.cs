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
    }
}
