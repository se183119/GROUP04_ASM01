using System;
using System.Windows;

namespace GROUP04WPF
{
    public partial class CoachDashboard : Window
    {
        public CoachDashboard()
        {
            InitializeComponent();
            LoadCoachData();
        }

        private void LoadCoachData()
        {
            // Get user information from application resources
            if (Application.Current.Resources["userName"] != null)
            {
                string userName = Application.Current.Resources["userName"].ToString();
                lblWelcome.Text = $"Welcome, Coach {userName}!";
            }

            // TODO: Load actual data from repositories
            // For now, showing placeholder data
            lblActiveMembers.Text = "0";
            lblSessionsThisWeek.Text = "0";
            lblSuccessRate.Text = "0%";
            lblAverageRating.Text = "0.0";
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
            LoadCoachData();
        }
    }
}