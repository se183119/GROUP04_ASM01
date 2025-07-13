using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GROUP04WPF
{
    public partial class RegisterWindow : Window
    {
        private readonly ICustomersRepositories _customerRepository;
        private readonly IMembershipPackageRepository _membershipRepository;
        private readonly ISmokingStatusRepository _smokingStatusRepository;
        
        private int _selectedMembershipPackageId = 0;
        private List<MembershipPackage> _membershipPackages;

        public RegisterWindow()
        {
            InitializeComponent();
            _customerRepository = new CustomerRepository();
            _membershipRepository = new MembershipPackageRepository();
            _smokingStatusRepository = new SmokingStatusRepository();
            
            LoadMembershipPackages();
        }

        private void LoadMembershipPackages()
        {
            try
            {
                _membershipPackages = _membershipRepository.GetActiveMembershipPackages();
                CreateMembershipPackageCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading membership packages: {ex.Message}");
                // Create default guest option
                _membershipPackages = new List<MembershipPackage>();
            }
        }

        private void CreateMembershipPackageCards()
        {
            membershipGrid.Children.Clear();
            
            // Add Guest option
            var guestCard = CreateMembershipCard(
                "Guest Account", 
                "Free", 
                "Basic platform access\n• View success stories\n• Browse achievements\n• Community access",
                0);
            membershipGrid.Children.Add(guestCard);
            Grid.SetColumn(guestCard, 0);

            // Add membership packages
            for (int i = 0; i < Math.Min(_membershipPackages.Count, 2); i++)
            {
                var package = _membershipPackages[i];
                var card = CreateMembershipCard(
                    package.PackageName,
                    $"${package.Price:F2}",
                    package.Features ?? package.Description ?? "Premium features",
                    package.MembershipPackageId);
                membershipGrid.Children.Add(card);
                Grid.SetColumn(card, i + 1);
            }
        }

        private Border CreateMembershipCard(string title, string price, string features, int packageId)
        {
            var border = new Border
            {
                Background = Brushes.White,
                BorderBrush = new SolidColorBrush(Color.FromRgb(224, 224, 224)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(5),
                Padding = new Thickness(20),
                Margin = new Thickness(5),
                Cursor = System.Windows.Input.Cursors.Hand
            };

            var stackPanel = new StackPanel();

            // Title
            var titleBlock = new TextBlock
            {
                Text = title,
                FontSize = 18,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 10)
            };
            stackPanel.Children.Add(titleBlock);

            // Price
            var priceBlock = new TextBlock
            {
                Text = price,
                FontSize = 24,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Color.FromRgb(76, 175, 80)),
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 15)
            };
            stackPanel.Children.Add(priceBlock);

            // Features
            var featuresBlock = new TextBlock
            {
                Text = features,
                FontSize = 12,
                TextWrapping = TextWrapping.Wrap,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 15)
            };
            stackPanel.Children.Add(featuresBlock);

            // Select button
            var selectButton = new Button
            {
                Content = "Select",
                Background = new SolidColorBrush(Color.FromRgb(33, 150, 243)),
                Foreground = Brushes.White,
                BorderThickness = new Thickness(0),
                Padding = new Thickness(15, 8),
                FontSize = 14
            };
            selectButton.Click += (s, e) => SelectMembershipPackage(packageId, border);
            stackPanel.Children.Add(selectButton);

            border.Child = stackPanel;
            return border;
        }

        private void SelectMembershipPackage(int packageId, Border selectedCard)
        {
            // Reset all cards
            foreach (Border card in membershipGrid.Children.OfType<Border>())
            {
                card.BorderBrush = new SolidColorBrush(Color.FromRgb(224, 224, 224));
                card.BorderThickness = new Thickness(1);
            }

            // Highlight selected card
            selectedCard.BorderBrush = new SolidColorBrush(Color.FromRgb(76, 175, 80));
            selectedCard.BorderThickness = new Thickness(3);

            _selectedMembershipPackageId = packageId;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            try
            {
                var valid = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return valid.IsMatch(email);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool ValidateStep1()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please enter your full name.");
                return false;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("Please enter a password.");
                return false;
            }

            if (txtPassword.Password != txtConfirmPassword.Password)
            {
                MessageBox.Show("Passwords do not match.");
                return false;
            }

            // Check if email already exists
            var existingCustomer = _customerRepository.GetCustomerByEmail(txtEmail.Text);
            if (existingCustomer != null)
            {
                MessageBox.Show("An account with this email already exists.");
                return false;
            }

            return true;
        }

        private bool ValidateStep2()
        {
            // Membership selection is optional, guest account is default
            return true;
        }

        private void ShowStep(int step)
        {
            panelStep1.Visibility = step == 1 ? Visibility.Visible : Visibility.Collapsed;
            panelStep2.Visibility = step == 2 ? Visibility.Visible : Visibility.Collapsed;
            panelStep3.Visibility = step == 3 ? Visibility.Visible : Visibility.Collapsed;

            // Update step indicators
            UpdateStepIndicator(1, step >= 1);
            UpdateStepIndicator(2, step >= 2);
            UpdateStepIndicator(3, step >= 3);
        }

        private void UpdateStepIndicator(int stepNumber, bool active)
        {
            Border stepBorder = stepNumber switch
            {
                1 => step1,
                2 => step2,
                3 => step3,
                _ => null
            };

            if (stepBorder != null)
            {
                stepBorder.Background = active ? 
                    new SolidColorBrush(Color.FromRgb(76, 175, 80)) : 
                    new SolidColorBrush(Color.FromRgb(224, 224, 224));
                
                var textBlock = (TextBlock)stepBorder.Child;
                textBlock.Foreground = active ? Brushes.White : new SolidColorBrush(Color.FromRgb(102, 102, 102));
            }
        }

        private void btnNext1_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateStep1())
            {
                ShowStep(2);
            }
        }

        private void btnBack2_Click(object sender, RoutedEventArgs e)
        {
            ShowStep(1);
        }

        private void btnNext2_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateStep2())
            {
                ShowStep(3);
            }
        }

        private void btnBack3_Click(object sender, RoutedEventArgs e)
        {
            ShowStep(2);
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create the customer
                var customer = new Customer
                {
                    CustomerFullName = txtFullName.Text,
                    Telephone = txtTelephone.Text,
                    EmailAddress = txtEmail.Text,
                    Password = txtPassword.Password,
                    CustomerBirthday = txtBirthDay.SelectedDate.HasValue ? 
                        DateOnly.FromDateTime(txtBirthDay.SelectedDate.Value) : null,
                    CustomerStatus = 1,
                    Role = _selectedMembershipPackageId > 0 ? UserRole.Member : UserRole.Guest,
                    MembershipPackageId = _selectedMembershipPackageId > 0 ? _selectedMembershipPackageId : null,
                    MembershipStartDate = _selectedMembershipPackageId > 0 ? DateTime.Now : null,
                    MembershipEndDate = _selectedMembershipPackageId > 0 ? 
                        DateTime.Now.AddDays(_membershipPackages.FirstOrDefault(p => p.MembershipPackageId == _selectedMembershipPackageId)?.DurationInDays ?? 30) : null,
                    CreatedDate = DateTime.Now
                };

                _customerRepository.CreateCustomer(customer);

                // Create initial smoking status if provided
                if (!string.IsNullOrWhiteSpace(txtCigarettesPerDay.Text) && 
                    int.TryParse(txtCigarettesPerDay.Text, out int cigarettesPerDay))
                {
                    var smokingStatus = new SmokingStatus
                    {
                        CustomerId = customer.CustomerId,
                        CigarettesPerDay = cigarettesPerDay,
                        MoneySpentPerDay = decimal.TryParse(txtMoneySpentPerDay.Text, out decimal money) ? money : 0,
                        SmokingTriggers = txtSmokingTriggers.Text,
                        SmokingTimes = txtSmokingTimes.Text,
                        Notes = txtNotes.Text,
                        RecordedDate = DateTime.Now
                    };

                    _smokingStatusRepository.CreateSmokingStatus(smokingStatus);
                }

                MessageBox.Show("Registration successful! Welcome to your journey to freedom!", 
                    "Registration Complete", MessageBoxButton.OK, MessageBoxImage.Information);

                // Navigate to login
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration failed: {ex.Message}", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
