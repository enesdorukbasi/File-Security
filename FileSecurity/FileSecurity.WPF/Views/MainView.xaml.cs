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
using System.Windows.Controls.Primitives;
using FileSecurity.WPF.Views.UserViews;
using FileSecurity.BL;
using FileSecurity.WPF.Views.MainViews;

namespace FileSecurity.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView(string userName)
        {
            InitializeComponent();

        }

        private void btnClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();
        }

        private void Home_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = btnHome;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopupText.Text = "Ana Ekran";
        }

        private void Home_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
        }

        private void btnSecurity_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = btnSecurity;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopupText.Text = "Güvenlik";
        }

        private void btnSecurity_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
        }

        private void btnSettings_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = btnSettings;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopupText.Text = "Ayarlar";
        }

        private void btnSettings_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
        }

        private void btnSecurity_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Source = new Uri("/Views/MainViews/SecurityView.xaml", UriKind.Relative);
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Source = new Uri("/Views/MainViews/HomeView.xaml", UriKind.Relative);
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Source = new Uri("/Views/MainViews/SettingsView.xaml", UriKind.Relative);
        }
    }
}
