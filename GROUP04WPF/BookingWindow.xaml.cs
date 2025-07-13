using BusinessObjects;
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
    /// Interaction logic for BookingWindow.xaml
    /// </summary>
    public partial class BookingWindow : Window
    {
        private readonly IBookingInformationRepositories _bookingInformationRepositories;
        private readonly ICustomersRepositories _customersRepositories;
        private readonly IBookingReservationRepositories _bookingReservationRepositories;
        string email = (string)Application.Current.Resources["email"];
        public BookingWindow()
        {
            InitializeComponent();
            _bookingInformationRepositories = new BookingInformationRepositories();
            _customersRepositories = new CustomerRepository();
            _bookingReservationRepositories = new BookingReservationRepositories();
            loadRoomNumber();
            loadCustomerID();
            DateTime today = DateTime.Now;
            txtBookingDate.Text = today.ToString();
        }
        private int customerIdByName;

        private void loadRoomNumber()
        {
            var room = _bookingInformationRepositories.GetAvailableRoom()
                .Select(ri => ri.RoomNumber).ToList();
            cmbRoomNumber.ItemsSource = room;
        }

        private void loadCustomerID()
        {
            var customer = _customersRepositories.GetCustomerByEmail(email);
            txtCustomerId.Text = customer.CustomerFullName;
            customerIdByName = customer.CustomerId;
        }

        private void txtStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidateDates();
        }

        private void txtEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidateDates();
        }

        private void ValidateDates()
        {
            if (txtStartDate.SelectedDate.HasValue && txtEndDate.SelectedDate.HasValue)
            {
                DateTime startDate = txtStartDate.SelectedDate.Value;
                DateTime endDate = txtEndDate.SelectedDate.Value;
                DateTime bookingDate = DateTime.Now;
                if (startDate.Day < bookingDate.Day)
                {
                    MessageBox.Show("Start Date must be greater than or equal to Booking Date.", "Invalid Date", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtStartDate.SelectedDate = null;
                    return;
                }
                if (endDate < startDate)
                {
                    MessageBox.Show("End Date must be greater than or equal to Start Date.", "Invalid Date", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtEndDate.SelectedDate = null;
                    return;
                }
                int numberOfDays = (endDate - startDate).Days;
                decimal actualPrice = decimal.Parse(txtActualPrice.Text);
                decimal totalPrice = (numberOfDays + 1) * actualPrice;
                txtTotalPrice.Text = totalPrice.ToString();
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            int customerId = customerIdByName;
            DateOnly bookingDate = DateOnly.FromDateTime(DateTime.Now);
            DateOnly startDate = DateOnly.FromDateTime(txtStartDate.SelectedDate.Value);
            DateOnly endDate = DateOnly.FromDateTime(txtEndDate.SelectedDate.Value);
            decimal actualPrice = decimal.Parse(txtActualPrice.Text);
            decimal totalPrice = decimal.Parse(txtTotalPrice.Text);
            var result = _bookingInformationRepositories.GetRoomInformationByRoomNumber(cmbRoomNumber.SelectedValue.ToString());
            var bookingReservation = new BookingReservation
            {
                BookingReservationId = AutoIncreaseId(),
                CustomerId = customerId,
                BookingDate = bookingDate,
                TotalPrice = totalPrice,
                BookingStatus = 1,
                BookingDetails = new List<BookingDetail>
                {
                    new BookingDetail
                    {
                        RoomId = result.RoomId,
                        StartDate = startDate,
                        EndDate = endDate,
                        ActualPrice = actualPrice
                    }
                }
            };
            _bookingReservationRepositories.CreateBookingReservation(bookingReservation);
            result.RoomStatus = 0;
            _bookingInformationRepositories.UpdateRoomInformation(result);
            MessageBox.Show("Booking created successfully!");
            Close();
        }

        private int AutoIncreaseId()
        {
            var maxId = _bookingReservationRepositories.GetMaxBookingReservationId();
            return maxId + 1;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cmbRoomNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var room = _bookingInformationRepositories.GetRoomInformationByRoomNumber(cmbRoomNumber.SelectedValue.ToString());
            if (room.RoomStatus == 1)
            {
                txtActualPrice.Text = room.RoomPricePerDay.ToString();
            }
        }
    }
}
