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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private readonly ICustomersRepositories _customerRepository;
        private readonly IBookingReservationRepositories _bookingReservationRepositories;
        private readonly IBookingInformationRepositories _bookingInformationRepositories;
        string email = (string)Application.Current.Resources["email"];

        public CustomerWindow()
        {
            InitializeComponent();
            _customerRepository = new CustomerRepository();
            _bookingReservationRepositories = new BookingReservationRepositories();
            _bookingInformationRepositories = new BookingInformationRepositories();
            loadCustomer();
        }

        private void loadCustomer()
        {
            var customer = _customerRepository.GetCustomerByEmail(email);
            txtCustomerID.Text = customer.CustomerId.ToString();
            txtFullName.Text = customer.CustomerFullName;
            txtPhone.Text = customer.Telephone;
            txtEmail.Text = customer.EmailAddress;
            txtBirthDay.Text = customer.CustomerBirthday.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var customer = _customerRepository.GetCustomerByEmail(email);
            customer.CustomerFullName = txtFullName.Text;
            customer.Telephone = txtPhone.Text;
            customer.CustomerBirthday = DateOnly.FromDateTime(txtBirthDay.SelectedDate.Value);
            _customerRepository.UpdateCustomer(customer);
            MessageBox.Show("Updated successfully!");
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            txtFullName.IsEnabled = true;
            txtPhone.IsEnabled = true;
            txtBirthDay.IsEnabled = true;
        }

        private void btnReservation_Click(object sender, RoutedEventArgs e)
        {
            var customer = _customerRepository.GetCustomerByEmail(email);
            LoadBookingReservation(customer.CustomerId);
        }

        private void LoadBookingReservation(int customerId)
        {
            dgData.Columns.Clear();
            dgData.Columns.Add(new DataGridTextColumn { Header = "Reservation ID", Binding = new Binding("BookingReservationId") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Booking Date", Binding = new Binding("BookingDate") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Total Price", Binding = new Binding("TotalPrice") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Customer Name", Binding = new Binding("Customer.CustomerFullName") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Status", Binding = new Binding("BookingStatus") });
            var source = _bookingReservationRepositories.GetReservationsByCustomerId(customerId);
            dgData.ItemsSource = source;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void btnChangesPwd_Click(object sender, RoutedEventArgs e)
        {
            ChangesPassword changesPassword = new ChangesPassword();
            changesPassword.Show();
        }

        private void btnBooking_Click(object sender, RoutedEventArgs e)
        {
            BookingWindow bookingWindow = new BookingWindow();
            bookingWindow.Show();
        }
    }
}
