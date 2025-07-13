using System;
using System.Windows;

namespace GROUP04WPF
{
    public partial class MemberDashboard : Window
    {
        public MemberDashboard()
        {
            InitializeComponent();
            LoadMemberData();
        }

        private void LoadMemberData()
        {
            // Get user information from application resources
            if (Application.Current.Resources["userName"] != null)
            {
                string userName = Application.Current.Resources["userName"].ToString();
                lblWelcome.Text = $"Welcome, {userName}!";
            }

            // TODO: Load actual data from repositories
            // For now, showing placeholder data
            lblDaysSmokeFree.Text = "0";
            lblMoneySaved.Text = "$0";
            lblCurrentStreak.Text = "0 days";
            lblAchievements.Text = "0";
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            // Clear session data
            Application.Current.Resources.Remove("email");
            Application.Current.Resources.Remove("userId");
            Application.Current.Resources.Remove("userRole");
            Application.Current.Resources.Remove("userName");

            // Navigate back to login
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            // Already on dashboard, maybe refresh data
            LoadMemberData();
        }
    }
}