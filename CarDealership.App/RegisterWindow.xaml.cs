﻿using System;
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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace CarDealership.App
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
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

            else if (!Regex.IsMatch(textBoxPhone.Text, "^[0-9]{8-12}$"))

            {
                errormessage.Text = "Enter a valid Phone Number !";

                textBoxPhone.Focus();

            }

        }
        }
    }
