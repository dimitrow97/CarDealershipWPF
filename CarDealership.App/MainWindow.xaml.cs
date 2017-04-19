using CarDealership.Data;
using CarDealership.Models.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace CarDealership.App
{
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();            
            CarDealershipContext context = new CarDealershipContext();
            //context.Database.Initialize(force: true);

            //Owner zhu = new Owner()
            //{
            //    FirstName = "Zhulian",
            //    LastName = "Dimitrov",
            //    Username = "dimitrow97",
            //    Password = Encrypt("123456"),
            //    Email = "dimitrow97@gmail.com",
            //    PhoneNumber = "0883552353"
            //};
            //context.Owners.Add(zhu);
            //Owner paco = new Owner()
            //{
            //    FirstName = "Plamen",
            //    LastName = "Parushev",
            //    Username = "paco",
            //    Password = Encrypt("654321"),
            //    Email = "paco@gmail.com",
            //    PhoneNumber = "0883641267"
            //};
            //context.Owners.Add(paco);

            //context.SaveChanges();
        }

        public static bool isOwner;
        public static string username;

        public static string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

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
                    if (password == Encrypt(this.passwordBox.Password))
                    {
                        isOwner = true;
                        username = this.textBox.Text;
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
                    if (password == Encrypt(this.passwordBox.Password))
                    {
                        isOwner = false;
                        username = this.textBox.Text;
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
