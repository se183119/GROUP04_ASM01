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
    /// Interaction logic for ChangeInfor.xaml
    /// </summary>
    public partial class ChangeInfor : Window
    {
        private readonly IBookingInformationRepositories _bookingInformationRepositories;
        private readonly IRoomTypeRepositories _roomTypeRepositories;

        public ChangeInfor()
        {
            InitializeComponent();
            _bookingInformationRepositories = new BookingInformationRepositories();
            _roomTypeRepositories = new RoomTypeRepositories();
            loadRoomType();
        }

        private int typeId;

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var inforId = int.Parse(txtSearchId.Text);
            var result = _bookingInformationRepositories.GetRoomInformation(inforId);
            if (result != null)
            {
                txtRoomNumber.Text = result.RoomNumber;
                txtRoomDetailDescription.Text = result.RoomDetailDescription;
                txtRoomMaxCapacity.Text = result.RoomMaxCapacity.ToString();
                var name = _roomTypeRepositories.GetRoomTypeById(result.RoomTypeId);
                cbRoomTypeId.Text = name.RoomTypeName;
                txtRoomStatus.Text = result.RoomStatus.ToString();
                txtRoomPricePerDay.Text = result.RoomPricePerDay.ToString();
                btnUpdate.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnSave.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Room information not found!");
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            txtRoomNumber.IsEnabled = true;
            txtRoomDetailDescription.IsEnabled = true;
            txtRoomMaxCapacity.IsEnabled = true;
            cbRoomTypeId.IsEnabled = true;
            txtRoomStatus.IsEnabled = true;
            txtRoomPricePerDay.IsEnabled = true;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete this room information?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirm == MessageBoxResult.Yes)
            {
                var inforId = int.Parse(txtSearchId.Text);
                _bookingInformationRepositories.DeleteRoomInformation(inforId);
                MessageBox.Show("Delete room information successfully!");
                Close();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var inforId = int.Parse(txtSearchId.Text);
            var result = _bookingInformationRepositories.GetRoomInformation(inforId);
            if (result != null)
            {
                result.RoomNumber = txtRoomNumber.Text;
                result.RoomDetailDescription = txtRoomDetailDescription.Text;
                result.RoomMaxCapacity = int.Parse(txtRoomMaxCapacity.Text);
                result.RoomTypeId = typeId;
                result.RoomStatus = Convert.ToByte(txtRoomStatus.Text);
                result.RoomPricePerDay = decimal.Parse(txtRoomPricePerDay.Text);
                _bookingInformationRepositories.UpdateRoomInformation(result);
                MessageBox.Show("Update room information successfully!");
                Close();
            }
            else
            {
                MessageBox.Show("Update room information failed!");
            }
        }

        private void loadRoomType()
        {
            var room = _roomTypeRepositories.GetAllRoomTypes()
                .Select(rt => rt.RoomTypeName).ToList(); ;
            cbRoomTypeId.ItemsSource = room;
        }

        private void cbRoomTypeId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var type = _roomTypeRepositories.GetRoomTypeByName(cbRoomTypeId.SelectedValue.ToString());
            typeId = type.RoomTypeId;
        }
    }
}
