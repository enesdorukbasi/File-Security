using System;
using Microsoft.Win32;
using WinForms = System.Windows.Forms;
using System.IO;
using System.Diagnostics;
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
using FileSecurity.WPF.Views.MainViews;

namespace FileSecurity.WPF.Views.MainViewInner
{
    /// <summary>
    /// Interaction logic for SecurityWindow.xaml
    /// </summary>
    public partial class SecurityWindow : Window
    {
        string filePath = "";

        public SecurityWindow(string filePath, string fileOrFolder, string situation, string securityMode)
        {
            InitializeComponent();
            lblFilePath.Text = filePath;
            txtFileOrFolder.Text = fileOrFolder;
            txtSituation.Text = situation;
            txtSecurityMode.Text = securityMode;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnOkey_Click(object sender, RoutedEventArgs e)
        {
            filePath = lblFilePath.Text.ToString();
            if (cbxSecurityModes.SelectedIndex == 0)
            {
                //Encrypted
                Byte[] file = File.ReadAllBytes(lblFilePath.Text);

                for (int i = 0; i < file.Length; i++)
                {
                    file[i] = (Byte)((int)file[i] + 1);
                    if (file[i] > 255)
                    {
                        file[i] = 0;
                    }
                }
                File.WriteAllBytes(filePath, file);
            }
            else if (cbxSecurityModes.SelectedIndex == 1)
            {
                //Hidden
                File.SetAttributes(filePath, FileAttributes.Hidden);
            }
            else if (cbxSecurityModes.SelectedIndex == 2)
            {
                //Encrypted And Hidden
                Byte[] file = File.ReadAllBytes(lblFilePath.Text);

                for (int i = 0; i < file.Length; i++)
                {
                    file[i] = (Byte)((int)file[i] + 1);
                    if (file[i] > 255)
                    {
                        file[i] = 0;
                    }
                }
                File.WriteAllBytes(filePath, file);

                File.SetAttributes(filePath, FileAttributes.Hidden);
            }

            lblFilePath.GetBindingExpression(TextBlock.TextProperty);
            txtFileName.GetBindingExpression(TextBox.TextProperty);
            cbxFileOrFolder.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
            cbxSituation.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
            txtEmail.GetBindingExpression(TextBlock.TextProperty);
            cbxSecurityModes.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
            DialogResult = true;
        }

    }
}
