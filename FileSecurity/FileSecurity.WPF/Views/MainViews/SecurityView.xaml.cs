using FileSecurity.BL;
using FileSecurity.WPF.ViewModels.FileViewModels;
using FileSecurity.WPF.Views.MainViewInner;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for SecurityView.xaml
    /// </summary>
    public partial class SecurityView : Page
    {
        string filePath = "", securityMode = "", situation = "", fileOrFolder = "";

        public SecurityView()
        {
            InitializeComponent();
            DataContext = new FileListViewModel();
        }

        private void btnSecurity_Click(object sender, RoutedEventArgs e)
        {
            filePath = ((TextBlock)datagrid.Columns[1].GetCellContent(datagrid.SelectedItem)).Text;
            fileOrFolder = ((TextBlock)datagrid.Columns[4].GetCellContent(datagrid.SelectedItem)).Text;
            situation = ((TextBlock)datagrid.Columns[3].GetCellContent(datagrid.SelectedItem)).Text;
            securityMode = ((TextBlock)datagrid.Columns[2].GetCellContent(datagrid.SelectedItem)).Text;
            SecurityWindow securityWindow = new SecurityWindow(filePath,fileOrFolder,situation,securityMode);
        }


        private void btnÇöz_Click(object sender, RoutedEventArgs e)
        {
            filePath = ((TextBlock)datagrid.Columns[1].GetCellContent(datagrid.SelectedItem)).Text;
            securityMode = ((TextBlock)datagrid.Columns[2].GetCellContent(datagrid.SelectedItem)).Text;
            situation = ((TextBlock)datagrid.Columns[3].GetCellContent(datagrid.SelectedItem)).Text;


            if(situation == "Safe")
            {
                if (securityMode == "Encrypted")
                {
                    Byte[] file = File.ReadAllBytes(filePath);

                    for (int i = 0; i < file.Length; i++)
                    {
                        if ((Byte)((int)file[i] - 1) < 0)
                        {
                            file[i] = 255;
                        }
                        else
                            file[i] = (Byte)((int)file[i] - 1);
                    }
                    File.WriteAllBytes(filePath, file);
                }
                else if (securityMode == "Hidden")
                {
                    File.SetAttributes(filePath, FileAttributes.Normal);
                }
                else if(securityMode == "EncryptedAndHidden")
                {
                    File.SetAttributes(filePath, FileAttributes.Normal);

                    Byte[] file = File.ReadAllBytes(filePath);

                    for (int i = 0; i < file.Length; i++)
                    {
                        if ((Byte)((int)file[i] - 1) < 0)
                        {
                            file[i] = 255;
                        }
                        else
                            file[i] = (Byte)((int)file[i] - 1);
                    }
                    File.WriteAllBytes(filePath, file);
                }
            }
        }
    }
}
