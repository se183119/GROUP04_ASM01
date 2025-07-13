using Microsoft.Extensions.Configuration;
using Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GROUP04WPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly ICustomersRepositories _customerRepository;
        public LoginWindow()
        {
            InitializeComponent();
            _customerRepository = new CustomerRepository();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtUser.Text.Trim();
            string password = txtPass.Password.Trim();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string adminEmail = config["DefaultAdminAccount:Email"];
            string adminPassword = config["DefaultAdminAccount:Password"];

            // Check if this is the default admin login
            if (email == adminEmail && password == adminPassword)
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                Close();
                return;
            }

            var customer = _customerRepository.GetCustomerByEmail(email);

            if (customer != null && customer.Password == password)
            {
                if (customer.CustomerStatus == 1) // Active status
                {
                    // Store user information for the session
                    Application.Current.Resources["email"] = email;
                    Application.Current.Resources["userId"] = customer.CustomerId;
                    Application.Current.Resources["userRole"] = customer.Role;
                    Application.Current.Resources["userName"] = customer.CustomerFullName;

                    // Update last login date
                    customer.LastLoginDate = DateTime.Now;
                    _customerRepository.UpdateCustomer(customer);

                    // Navigate based on role
                    switch (customer.Role)
                    {
                        case BusinessObjects.UserRole.Admin:
                            AdminWindow adminWindow = new AdminWindow();
                            adminWindow.Show();
                            break;
                        case BusinessObjects.UserRole.Coach:
                            CoachDashboard coachDashboard = new CoachDashboard();
                            coachDashboard.Show();
                            break;
                        case BusinessObjects.UserRole.Member:
                            MemberDashboard memberDashboard = new MemberDashboard();
                            memberDashboard.Show();
                            break;
                        case BusinessObjects.UserRole.Guest:
                        default:
                            GuestDashboard guestDashboard = new GuestDashboard();
                            guestDashboard.Show();
                            break;
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("Your account is inactive. Please contact support.", "Account Inactive", 
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid email or password", "Login Failed", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            string email = txtUser.Text;
            if (!IsValidEmail(email))
            {
                txtUser.BorderBrush = System.Windows.Media.Brushes.Red;
                txtUser.ToolTip = "Invalid email format";
            }
            else
            {
                txtUser.BorderBrush = System.Windows.Media.Brushes.DarkGray;
                txtUser.ToolTip = null;
            }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var valid = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return valid.IsMatch(email);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            Close();
        }        
    }
}
