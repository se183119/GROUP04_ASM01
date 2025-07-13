using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly ICustomersRepositories _customerRepository;

        public RegisterWindow()
        {
            InitializeComponent();
            _customerRepository = new CustomerRepository();
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
            try
            {
                string email = txtEmail.Text;
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Invalid email format");
                    return;
                }

                var result = _customerRepository.GetCustomerByEmail(email);
                if (result == null)
                {
                    var customer = new Customer
                    {
                        CustomerFullName = txtFullName.Text,
                        Telephone = txtTelephone.Text,
                        EmailAddress = txtEmail.Text,
                        Password = txtPassword.Text,
                        CustomerBirthday = DateOnly.FromDateTime(txtBirthDay.SelectedDate.Value),
                        CustomerStatus = 1
                    };
                    _customerRepository.CreateCustomer(customer);
                    MessageBox.Show("Registration successful!");
                }
                else
                {
                    MessageBox.Show("Customer already exist!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            Close();
        }

        private void txtFullName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
