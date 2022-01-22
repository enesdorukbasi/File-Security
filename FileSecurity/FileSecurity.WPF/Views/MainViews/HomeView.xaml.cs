using FileSecurity.BL;
using FileSecurity.EL;
using FileSecurity.WPF.ViewModels.UserViewModels;
using FileSecurity.WPF.Views.UserViews;
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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Page
    {
        public HomeView()
        {
            InitializeComponent();
            if (App.User != null)
            {
                txtName.Text = App.User.UserName;
                string eMail = App.User.EMail;

                FileManager fileManager = new FileManager();
                if (fileManager.ListWithUser(eMail).Count() != 0)
                {
                    txtRegisteredFileCount.Text = fileManager.ListWithUser(App.User.EMail).Count().ToString();
                    txtSafedFileCount.Text = fileManager.ListWithUser(App.User.EMail).Where(x => x.Situation == Situations.Safe).Count().ToString();
                    txtEncryptedFileCount.Text = fileManager.ListWithUser(App.User.EMail).Where(x => x.SecurityMode == SecurityModes.Encrypted).Count().ToString();
                    txtHiddenFileCount.Text = fileManager.ListWithUser(App.User.EMail).Where(x => x.SecurityMode == SecurityModes.Hidden).Count().ToString();
                    txtEncryptedAndHiddenFileCount.Text = fileManager.ListWithUser(App.User.EMail).Where(x => x.SecurityMode == SecurityModes.EncryptedAndHidden).Count().ToString();  
                }
                else if(fileManager.ListWithUser(eMail).Count() == 0)
                {
                    stpTexts.Visibility = Visibility.Hidden;

                }
            }
        }
    }
}
