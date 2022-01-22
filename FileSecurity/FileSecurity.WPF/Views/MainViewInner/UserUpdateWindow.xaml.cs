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

namespace FileSecurity.WPF.Views.MainViewInner
{
    /// <summary>
    /// Interaction logic for UserUpdateWindow.xaml
    /// </summary>
    public partial class UserUpdateWindow : Window
    {
        public UserUpdateWindow()
        {
            InitializeComponent();
        }

        private void btnOkey_Click(object sender, RoutedEventArgs e)
        {
            txtUserMail.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtUserPassword.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtUserName.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
