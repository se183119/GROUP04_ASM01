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
    /// Interaction logic for ChangeReservation.xaml
    /// </summary>
    public partial class ChangeReservation : Window
    {
        private readonly IBookingReservationRepositories _bookingReservationRepositories;
        private readonly IBookingInformationRepositories _bookingInformationRepositories;
        private readonly IBookingDetailRepositories _bookingDetailRepositories;
        private readonly ICustomersRepositories _customersRepositories;

        public ChangeReservation()
        {
            InitializeComponent();
            _bookingReservationRepositories = new BookingReservationRepositories();
            _bookingInformationRepositories = new BookingInformationRepositories();
            _bookingDetailRepositories = new BookingDetailRepositories();
            _customersRepositories = new CustomerRepository();
            loadRoomNumber();
        }

        private void loadRoomNumber()
        {
            var room = _bookingInformationRepositories.GetRoomInformationList()
                .Select(ri => ri.RoomNumber).ToList();
            cmbRoomNumber.ItemsSource = room;
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

        private void cmbRoomNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var room = _bookingInformationRepositories.GetRoomInformationByRoomNumber(cmbRoomNumber.SelectedValue.ToString());
            if (room != null)
            {
                txtActualPrice.Text = room.RoomPricePerDay.ToString();
                ValidateDates();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            int reserId = int.Parse(txtSearch.Text);
            var result = _bookingReservationRepositories.GetBookingReservation(reserId);
            if (result != null)
            {
                var room = _bookingDetailRepositories.GetBookingDetailById(result.BookingReservationId);
                cmbRoomNumber.Text = room.Room.RoomNumber;
                txtCustomerId.Text = result.Customer.CustomerFullName;
                txtBookingDate.SelectedDate = result.BookingDate?.ToDateTime(new TimeOnly(0, 0));
                txtStartDate.SelectedDate = room.StartDate.ToDateTime(new TimeOnly(0, 0));
                txtEndDate.SelectedDate = room.EndDate.ToDateTime(new TimeOnly(0, 0));
                txtActualPrice.Text = room.ActualPrice.ToString();
                txtTotalPrice.Text = result.TotalPrice.ToString();

                btnUpdate.IsEnabled = true;
                btnSave.IsEnabled = true;
                btnCancel.IsEnabled = true;
                btnDelete.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Not found!");
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            cmbRoomNumber.IsEnabled = true;
            txtStartDate.IsEnabled = true;
            txtEndDate.IsEnabled = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int reserId = int.Parse(txtSearch.Text);
            var result = _bookingReservationRepositories.GetBookingReservation(reserId);
            if (result != null)
            {
                var bookingDetail = _bookingDetailRepositories.GetBookingDetailById(result.BookingReservationId);
                if (bookingDetail != null)
                {
                    var oldRoom = _bookingInformationRepositories.GetRoomInformation(bookingDetail.RoomId);
                    var newRoom = _bookingInformationRepositories.GetRoomInformationByRoomNumber(cmbRoomNumber.SelectedValue.ToString());

                    oldRoom.RoomStatus = 1;
                    _bookingInformationRepositories.UpdateRoomInformation(oldRoom);

                    _bookingDetailRepositories.DeleteBookingDetail(bookingDetail.BookingReservationId);
                    var newBookingDetail = new BookingDetail
                    {
                        BookingReservationId = bookingDetail.BookingReservationId,
                        RoomId = newRoom.RoomId,
                        StartDate = DateOnly.FromDateTime(txtStartDate.SelectedDate.Value),
                        EndDate = DateOnly.FromDateTime(txtEndDate.SelectedDate.Value),
                        ActualPrice = newRoom.RoomPricePerDay
                    };
                    _bookingDetailRepositories.CreateBookingDetail(newBookingDetail);

                    newRoom.RoomStatus = 0;
                    _bookingInformationRepositories.UpdateRoomInformation(newRoom);
                }

                result.TotalPrice = decimal.Parse(txtTotalPrice.Text);
                var confirm = MessageBox.Show("Are you sure you want to update this room reservation?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirm == MessageBoxResult.Yes)
                {
                    _bookingReservationRepositories.UpdateBookingReservation(result);
                    MessageBox.Show("Update room reservation successfully!");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Update room reservation failed!");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete this room reservation?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirm == MessageBoxResult.Yes)
            {
                var inforId = int.Parse(txtSearch.Text);
                _bookingReservationRepositories.DeleteBookingReservation(inforId);
                MessageBox.Show("Delete room reservation successfully!");
                Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
