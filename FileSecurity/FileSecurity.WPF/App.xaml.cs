using FileSecurity.EL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FileSecurity.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static User User { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Window mainView = new Views.MainView();

            //Views.UserViews.LoginView view = new Views.UserViews.LoginView();
            //if (view.ShowDialog() == true)
            //{
            //    mainView.DialogResult = false;
            //    MainWindow = mainView;
            //    MainWindow.Show();
            //}
            //else if(mainView.ShowDialog() == true)
            //{
            //    view.DialogResult == false;
            //}
        }
    }
}
