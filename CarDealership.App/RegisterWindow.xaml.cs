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
using System.Text.RegularExpressions;
using System.Security.Cryptography;


namespace CarDealership.App
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        public static string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxUsername.Text.Length == 0)
            {
                errormessage.Text = "Enter an Username !";
                textBoxUsername.Focus();
            }     
                                                    
            else if (!Regex.IsMatch(textBoxUsername.Text, "^[a-zA-Z][a-zA-Z0-9]{5,16}$"))
            {
                errormessage.Text = "Enter a valid Username !";
                textBoxUsername.Select(0, textBoxUsername.Text.Length);
                textBoxUsername.Focus();
            }

            else if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "Enter an E-mail !";
                textBoxEmail.Focus();
            }

            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid E-mail !";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }

                else if (passwordBox1.Password.Length == 0)
                {
                    errormessage.Text = "Enter Password !";
                    passwordBox1.Focus();
                }

            else if (!Regex.IsMatch(passwordBox1.Password, "[a-zA-Z0-9]{6,16}$"))
            {
                errormessage.Text = "Enter a valid Password !";
                passwordBox1.Focus();
            }

            else if (passwordBox2.Password.Length == 0)
                {
                    errormessage.Text = "Enter Confirm password.";
                    passwordBox2.Focus();
                }

             else if (passwordBox1.Password != passwordBox2.Password)
                {
                    errormessage.Text = "Confirm password must be same as password.";
                    passwordBox2.Focus();
                }

            else if (textBoxFirstName.Text.Length == 0)
            {
                errormessage.Text = "Enter a First Name !";
                textBoxFirstName.Focus();
            }

            else if (!Regex.IsMatch(textBoxFirstName.Text, "^[A-Z][a-zA-Z]*$"))
            {
                errormessage.Text = "Enter a valid First Name !";
                textBoxFirstName.Focus();

            }

            else if (textBoxLastName.Text.Length == 0)
            {
                errormessage.Text = "Enter a Last Name !";
                textBoxLastName.Focus();
            }

            else if (!Regex.IsMatch(textBoxLastName.Text, "^[A-Z][a-zA-Z]*$"))
            {
                errormessage.Text = "Enter a valid Last Name !";
                textBoxLastName.Focus();
            }

            else if (textBoxPhone.Text.Length == 0)                
            {
                errormessage.Text = "Enter a Phone Number !";                
                textBoxPhone.Focus();
            }
            
             else if (!Regex.IsMatch(textBoxPhone.Text, @"^-*[0-9,\.]+$"))                
            {
                errormessage.Text = "Enter a valid Phone Number !";                
                textBoxPhone.Focus();                
            }          

            else 
            {
                CarDealershipContext context = new CarDealershipContext();

                var userNameFromDb = context.Customers.Select(x => x.Username).ToList();
                var emailFromDb = context.Customers.Select(x => x.Email).ToList();
                var phoneFromDb = context.Customers.Select(x => x.PhoneNumber).ToList();                

                if (userNameFromDb.Contains(textBoxUsername.Text))
                {
                    errormessage.Text = "Username already exists !";
                    textBoxUsername.Focus();
                }

                else if (emailFromDb.Contains(textBoxEmail.Text))
                {
                    errormessage.Text = "E-mail already exists !";
                    textBoxEmail.Focus();
                }

                else if (phoneFromDb.Contains(textBoxPhone.Text))
                {
                    errormessage.Text = "Telephone number already exists !";
                    textBoxPhone.Focus();
                }

                else
                {
                    Customer customer = new Customer()
                    {
                        Username = textBoxUsername.Text,
                        Email = textBoxEmail.Text,
                        Password = Encrypt(passwordBox1.Password),
                        FirstName = textBoxFirstName.Text,
                        LastName = textBoxLastName.Text,
                        PhoneNumber = textBoxPhone.Text
                    };

                    context.Customers.Add(customer);
                    context.SaveChanges();
                    
                    MessageBox.Show("You have Registered successfully.");
                    MainWindow win = new MainWindow();
                    win.Show();
                    Close();
                }
            }
         }
      }
   }

