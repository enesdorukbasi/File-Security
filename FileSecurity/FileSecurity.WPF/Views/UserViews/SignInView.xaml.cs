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
    /// Interaction logic for SignInView.xaml
    /// </summary>
    public partial class SignInView : Window
    {
        public SignInView()
        {
            InitializeComponent();
        }

        private void btnBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DialogResult = false;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnOkay_Click(object sender, RoutedEventArgs e)
        {
            txtUserMail.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtUserPassword.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtUserName.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            DialogResult = true;
        }
    }
}
