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
    /// Interaction logic for CreateRoomType.xaml
    /// </summary>
    public partial class CreateRoomType : Window
    {
        private readonly IRoomTypeRepositories _roomTypeRepositories;

        public CreateRoomType()
        {
            InitializeComponent();
            _roomTypeRepositories = new RoomTypeRepositories();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var result = _roomTypeRepositories.GetRoomTypeByName(txtTypeName.Text);
            if (result == null)
            {
                var roomType = new RoomType
                {
                    RoomTypeName = txtTypeName.Text,
                    TypeDescription = txtDescription.Text,
                    TypeNote = txtNote.Text,
                };
                _roomTypeRepositories.CreateRoomType(roomType);
                MessageBox.Show("Create Room Type successfully!");
                Close();
            }
            else
            {
                MessageBox.Show("Room type already exits!");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
