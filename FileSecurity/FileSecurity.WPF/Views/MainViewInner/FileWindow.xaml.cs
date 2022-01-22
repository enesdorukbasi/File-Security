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
    /// Interaction logic for FileWindow.xaml
    /// </summary>
    public partial class FileWindow : Window
    {
        public FileWindow()
        {
            InitializeComponent();
        }

        private void btnOkey_Click(object sender, RoutedEventArgs e)
        {
            lblFilePath.GetBindingExpression(TextBlock.TextProperty);
            txtFileName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            cbxFileOrFolder.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnSelectFolder_Click_1(object sender, RoutedEventArgs e)
        {
            WinForms.FolderBrowserDialog dlg = new WinForms.FolderBrowserDialog();
            dlg.ShowNewFolderButton = true;
            dlg.RootFolder = Environment.SpecialFolder.MyComputer;
            dlg.ShowDialog();
            lblFilePath.Text = dlg.SelectedPath;

            if (lblFilePath.Text != null || lblFilePath.Text != "")
            {
                cbxFileOrFolder.SelectedIndex = 1;
            }
        }

        private void btnSelectFile_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            lblFilePath.Text = dlg.FileName.ToString();
            cbxFileOrFolder.SelectedIndex = 0;
        }
    }
}
