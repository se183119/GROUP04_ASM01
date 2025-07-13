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
    /// Interaction logic for ChangeRoomType.xaml
    /// </summary>
    public partial class ChangeRoomType : Window
    {
        private readonly IRoomTypeRepositories _roomTypeRepositories;

        public ChangeRoomType()
        {
            InitializeComponent();
            _roomTypeRepositories = new RoomTypeRepositories();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var typeId = int.Parse(txtSearchId.Text);
            var result = _roomTypeRepositories.GetRoomTypeById(typeId);
            if (result != null)
            {
                txtRoomTypeName.Text = result.RoomTypeName;
                txtTypeDescription.Text = result.TypeDescription;
                txtTypeNote.Text = result.TypeNote;
                btnUpdate.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnSave.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Room type not found!");
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            txtRoomTypeName.IsEnabled = true;
            txtTypeDescription.IsEnabled = true;
            txtTypeNote.IsEnabled = true;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete this room type?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirm == MessageBoxResult.Yes)
            {
                var typeId = int.Parse(txtSearchId.Text);
                _roomTypeRepositories.DeleteRoomType(typeId);
                MessageBox.Show("Delete room type successfully!");
                Close();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var typeId = int.Parse(txtSearchId.Text);
            var result = _roomTypeRepositories.GetRoomTypeById(typeId);
            if (result != null)
            {
                result.RoomTypeName = txtRoomTypeName.Text;
                result.TypeDescription = txtTypeDescription.Text;
                result.TypeNote = txtTypeNote.Text;
                _roomTypeRepositories.UpdateRoomType(result);
                MessageBox.Show("Update room type successfully!");
                Close();
            }
            else
            {
                MessageBox.Show("Update room type failed!");
            }
        }
    }
}
