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
    /// Interaction logic for CreateCustomer.xaml
    /// </summary>
    public partial class CreateCustomer : Window
    {
        private readonly ICustomersRepositories _customersRepositories;
        public CreateCustomer()
        {
            InitializeComponent();
            _customersRepositories = new CustomerRepository();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format");
                return;
            }

            var result = _customersRepositories.GetCustomerByEmail(email);
            if (result == null)
            {
                var customer = new Customer
                {
                    CustomerFullName = txtFullName.Text,
                    Telephone = txtPhone.Text,
                    EmailAddress = txtEmail.Text,
                    CustomerBirthday = DateOnly.FromDateTime(txtBirthDay.SelectedDate.Value),
                    CustomerStatus = 1,
                    Password = txtPassword.Password
                };
                _customersRepositories.CreateCustomer(customer);
                MessageBox.Show("Create customer successfully!");
                Close();
            }
            else
            {
                MessageBox.Show("Customer already exist!");
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

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
