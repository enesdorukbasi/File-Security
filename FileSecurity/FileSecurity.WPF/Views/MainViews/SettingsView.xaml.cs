using FileSecurity.WPF.ViewModels.UserViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileSecurity.WPF.Views.MainViews
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Page
    {
        public SettingsView()
        {
            InitializeComponent();
            DataContext = new UserListViewModel();
            if (App.User != null)
            {
                txtbUserName.Text = App.User.UserName;
                txtUserMail.Text = App.User.EMail;
            }
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
