using Repositories;
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
using System.Windows.Shapes;

namespace GROUP04WPF
{
    /// <summary>
    /// Interaction logic for ChangesPassword.xaml
    /// </summary>
    public partial class ChangesPassword : Window
    {
        string email = (string)Application.Current.Resources["email"];
        private readonly CustomerRepository _customerRepository;

        public ChangesPassword()
        {
            InitializeComponent();
            _customerRepository = new CustomerRepository();
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            var customer = _customerRepository.GetCustomerByEmail(email);
            if (customer.Password != txtCurrentPassword.Text)
            {
                MessageBox.Show("Incorrect password! Please try again.");
            }
            else
            {
                if (txtConfirmPassword.Text != txtNewPassword.Text)
                {
                    MessageBox.Show("Confirm Password is incorrect with New Password");
                }
                else
                {
                    customer.Password = txtConfirmPassword.Text;
                    _customerRepository.UpdateCustomer(customer);
                    MessageBox.Show("Change password successfully!");
                }
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
