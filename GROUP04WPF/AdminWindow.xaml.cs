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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly ICustomersRepositories _customersRepositories;
        private readonly IBookingDetailRepositories _bookingDetailRepositories;
        private readonly IBookingInformationRepositories _bookingInformationRepositories;
        private readonly IBookingReservationRepositories _bookingReservationRepositories;
        private readonly IRoomTypeRepositories _roomTypeRepositories;
        public AdminWindow()
        {
            InitializeComponent();
            _bookingDetailRepositories = new BookingDetailRepositories();
            _bookingInformationRepositories = new BookingInformationRepositories();
            _bookingReservationRepositories = new BookingReservationRepositories();
            _customersRepositories = new CustomerRepository();
            _roomTypeRepositories = new RoomTypeRepositories();
            _bookingInformationRepositories.UpdateExpiredReservations();
        }
        private string curTextBlock;

        private void RoomInformation_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            btn_Create.Visibility = Visibility.Visible;
            btn_Change.Visibility = Visibility.Visible;
            dgData.Columns.Clear();
            var roomInformations = _bookingInformationRepositories.GetAvailableRoom();
            dgData.Columns.Add(new DataGridTextColumn { Header = "Room Number", Binding = new Binding("RoomNumber") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Room Details Description", Binding = new Binding("RoomDetailDescription") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Room Max Capacity", Binding = new Binding("RoomMaxCapacity") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Room Type", Binding = new Binding("RoomType.RoomTypeName") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Room Status", Binding = new Binding("RoomStatus") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Room Price Per Day", Binding = new Binding("RoomPricePerDay") });
            dgData.ItemsSource = roomInformations;
            curTextBlock = "Infor";
        }

        private void RoomType_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            btn_Create.Visibility = Visibility.Visible;
            btn_Change.Visibility = Visibility.Visible;
            dgData.Columns.Clear();
            var roomTypes = _roomTypeRepositories.GetAllRoomTypes();
            dgData.Columns.Add(new DataGridTextColumn { Header = "No", Binding = new Binding("RoomTypeId") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Room Type Name", Binding = new Binding("RoomTypeName") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Type Description", Binding = new Binding("TypeDescription") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Type Note", Binding = new Binding("TypeNote") });
            dgData.ItemsSource = roomTypes;
            curTextBlock = "Type";
        }

        private void Customer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            btn_Create.Visibility = Visibility.Visible;
            btn_Change.Visibility = Visibility.Visible;
            dgData.Columns.Clear();
            var customers = _customersRepositories.GetAllCustomers();
            dgData.Columns.Add(new DataGridTextColumn { Header = "CustomerFullName", Binding = new Binding("CustomerFullName") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Telephone", Binding = new Binding("Telephone") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Email Address", Binding = new Binding("EmailAddress") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Customer Birthday", Binding = new Binding("CustomerBirthday") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Customer Status", Binding = new Binding("CustomerStatus") });
            dgData.ItemsSource = customers;
            curTextBlock = "Customer";
        }

        private void BookingReservation_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            btn_Create.Visibility = Visibility.Visible;
            btn_Change.Visibility = Visibility.Visible;
            dgData.Columns.Clear();
            var bookingReservations = _bookingReservationRepositories.GetAvailableBookingReservation();
            dgData.Columns.Add(new DataGridTextColumn { Header = "Reservation ID", Binding = new Binding("BookingReservationId") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Booking Date", Binding = new Binding("BookingDate") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Total Price", Binding = new Binding("TotalPrice") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Customer Name", Binding = new Binding("Customer.CustomerFullName") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Status", Binding = new Binding("BookingStatus") });
            dgData.ItemsSource = bookingReservations;
            curTextBlock = "Reservation";
        }

        private void BookingDetail_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            btn_Create.Visibility = Visibility.Hidden;
            btn_Change.Visibility = Visibility.Hidden;
            dgData.Columns.Clear();
            var bookingDetails = _bookingDetailRepositories.GetAllBookingDetail();
            dgData.Columns.Add(new DataGridTextColumn { Header = "Booking Date", Binding = new Binding("BookingReservation.BookingDate") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Room Number", Binding = new Binding("Room.RoomNumber") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Start Date", Binding = new Binding("StartDate") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "End Date", Binding = new Binding("EndDate") });
            dgData.Columns.Add(new DataGridTextColumn { Header = "Actual Price", Binding = new Binding("ActualPrice") });
            dgData.ItemsSource = bookingDetails;            
        }

        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            switch (curTextBlock)
            {
                case "Infor":
                    CreateInfor createInfor = new CreateInfor();
                    createInfor.Show();
                    break;

                case "Type":
                    CreateRoomType createType = new CreateRoomType();
                    createType.Show();
                    break;

                case "Customer":
                    CreateCustomer customer = new CreateCustomer();
                    customer.Show();
                    break;

                case "Reservation":
                    CreateReservation reservation = new CreateReservation();
                    reservation.Show();
                    break;
                default:
                    break;
            }
        }

        private void btn_Change_Click(object sender, RoutedEventArgs e)
        {
            switch (curTextBlock)
            {
                case "Infor":
                    ChangeInfor changeInfor = new ChangeInfor();
                    changeInfor.Show();
                    break;

                case "Type":
                    ChangeRoomType changeType = new ChangeRoomType();
                    changeType.Show();
                    break;

                case "Customer":
                    ChangeCustomer customer = new ChangeCustomer();
                    customer.Show();
                    break;

                case "Reservation":
                    ChangeReservation reservation = new ChangeReservation();
                    reservation.Show();
                    break;

                default:
                    break;
            }
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }
    }
}
