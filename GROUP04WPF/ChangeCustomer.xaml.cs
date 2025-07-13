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
    /// Interaction logic for ChangeCustomer.xaml
    /// </summary>
    public partial class ChangeCustomer : Window
    {
        private readonly ICustomersRepositories _customersRepositories;
        public ChangeCustomer()
        {
            InitializeComponent();
            _customersRepositories = new CustomerRepository();
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var customerId = int.Parse(txtSearchId.Text);
            var result = _customersRepositories.GetCustomerById(customerId);
            if (result != null)
            {
                txtFullName.Text = result.CustomerFullName;
                txtTelephone.Text = result.Telephone;
                txtEmail.Text = result.EmailAddress;
                txtBirthday.Text = result.CustomerBirthday.ToString();
                txtStatus.Text = result.CustomerStatus.ToString();
                txtPassword.Text = result.Password;
                btnUpdate.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnSave.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Customer not found!");
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            txtFullName.IsEnabled = true;
            txtTelephone.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtBirthday.IsEnabled = true;
            txtStatus.IsEnabled = true;
            txtPassword.IsEnabled = true;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete this customer?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirm == MessageBoxResult.Yes)
            {
                var customerId = int.Parse(txtSearchId.Text);
                _customersRepositories.DeleteCustomer(customerId);
                MessageBox.Show("Delete customer successfully!");
                Close();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format");
                return;
            }

            var customerId = int.Parse(txtSearchId.Text);
            var result = _customersRepositories.GetCustomerById(customerId);
            if (result != null)
            {
                result.CustomerFullName = txtFullName.Text;
                result.Telephone = txtTelephone.Text;
                result.EmailAddress = txtEmail.Text;
                result.CustomerBirthday = DateOnly.FromDateTime(txtBirthday.SelectedDate.Value);
                result.CustomerStatus = Convert.ToByte(txtStatus.Text);
                result.Password = txtPassword.Text;
                _customersRepositories.UpdateCustomer(result);
                MessageBox.Show("Update customer successfully!");
                Close();
            }
            else
            {
                MessageBox.Show("Update customer failed!");
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
    }
}
