using CarDealership.Data;
using CarDealership.Models.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarDealership.App
{
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();            
            CarDealershipContext context = new CarDealershipContext();
            context.Database.Initialize(force: true);           

            Owner zhu = new Owner()
            {
                FirstName = "Zhulian",
                LastName = "Dimitrov",
                Username = "dimitrow97",
                Password = "123456",
                Email = "dimitrow00@gmail.com",
                PhoneNumber = "0883552353"
            };
            context.Owners.Add(zhu);
            Owner paco = new Owner()
            {
                FirstName = "Plamen",
                LastName = "Parushev",
                Username = "paco",
                Password = "654321",
                Email = "paco@gmail.com",
                PhoneNumber = "0883641267"
            };
            context.Owners.Add(paco);

            Car audi = new Car()
            {
                Make = "Audi",
                Model = "A3",
                ProductionYear = "2007",
                BodyPaint = "Black Metalic",
                Price = 10000
            };
            context.Cars.Add(audi);
            context.SaveChanges();            
        }

        public static bool isOwner;

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            
            RegisterWindow win2 = new RegisterWindow();
            win2.Show();
            Close();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            CarDealershipContext context = new CarDealershipContext();                     

            using (context)
            {
                var usernamesOwners = context.Owners.Select(x => x.Username).ToList();
                var usernamesCustomers = context.Customers.Select(x => x.Username).ToList();
                if (usernamesOwners.Contains(this.textBox.Text))
                {
                    var password = context.Owners.Where(x => x.Username == this.textBox.Text).Select(y => y.Password).FirstOrDefault();
                    if (password == this.passwordBox.Password)
                    {
                        isOwner = true;
                        MainMenu mainMenuForm = new MainMenu();
                        Close();
                        mainMenuForm.Show();                                                
                    }
                    else
                    {
                        MessageBox.Show("Invalid Password!", "Important!", MessageBoxButton.OK, MessageBoxImage.Error);
                        passwordBox.Clear();
                    }
                }
                else if (usernamesCustomers.Contains(this.textBox.Text))
                {
                    var password = context.Customers.Where(x => x.Username == this.textBox.Text).Select(y => y.Password).FirstOrDefault();
                    if (password == this.passwordBox.Password)
                    {
                        isOwner = false;
                        MainMenu mainMenuForm = new MainMenu();
                        Close();                        
                        mainMenuForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Password!", "Important!", MessageBoxButton.OK, MessageBoxImage.Error);
                        passwordBox.Clear();
                    }
                }
                else MessageBox.Show("Invalid Username!", "Important!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }        
    }
}
