using FileSecurity.BL;
using FileSecurity.WPF.ViewModels.UserViewModels;
using FileSecurity.WPF.Views.MainViews;
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

namespace FileSecurity.WPF.Views.UserViews
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public string email;
        MainView mainView = new MainView("");

        public LoginView()
        {
            InitializeComponent(); 
            DataContext = new UserListViewModel();

            using (UserManager manager = new UserManager())
            {
                if (manager.List().Count() <= 0)
                {
                    btnSignIn.Visibility = Visibility.Visible;
                }
                else
                {
                    btnSignIn.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (UserManager manager = new UserManager())
            {
                if (manager.Login(txtUserMail.Text, txtUserPassword.Password))
                {
                    App.User = manager.GetUser(txtUserMail.Text);
                    string userName = App.User.UserName;
                    MainView mainView = new MainView(userName);
                    email = txtUserMail.Text.ToLower();
                    mainView.Show();
                    this.Close();
                }
                else
                {
                    txtHata.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
