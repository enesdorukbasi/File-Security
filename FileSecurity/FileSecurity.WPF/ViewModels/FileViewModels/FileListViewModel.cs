using FileSecurity.BL;
using FileSecurity.EL;
using FileSecurity.WPF.Commands;
using FileSecurity.WPF.Views.MainViewInner;
using FileSecurity.WPF.Views.MainViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FileSecurity.WPF.ViewModels.FileViewModels
{
    public class FileListViewModel : BaseViewModel
    {
        private FileManager manager;

        private ObservableCollection<FileViewModel> _items;
        private FileViewModel _selectedItem;

        public ObservableCollection<FileViewModel> Items
        {
            get { return _items; }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged();
                }
            }
        }

        public FileViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand RefreshCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand SolveCommand { get; set; }

        public FileListViewModel()
        {
            manager = new FileManager();
            OnRefresh();

            RefreshCommand = new RelayCommand(o => { OnRefresh(); }, o => { return true; });
            InsertCommand = new RelayCommand(o => { OnInsert(); }, o => { return true; });
            DeleteCommand = new RelayCommand((parameter) => { OnDelete(parameter); }, o => { return _selectedItem != null; });
            UpdateCommand = new RelayCommand((parameter) => { OnUpdate(parameter); }, o => { return _selectedItem != null; });
            SolveCommand = new RelayCommand((parameter) => { OnSolve(parameter); }, o => { return _selectedItem != null; });
            OnRefresh();
        }

        private void OnRefresh()
        {
            Items = new ObservableCollection<FileViewModel>();
            List<File> files = manager.ListWithUser(App.User.EMail);
            foreach (var item in files)
            {
                Items.Add(new FileViewModel(item));
            }
        }

        private void OnInsert()
        {
            FileViewModel vm = new FileViewModel();
            FileWindow view = new FileWindow() { DataContext = vm };
            vm.FilePath = view.lblFilePath.Text.ToString();
            string fileName = view.txtFileName.Text;
            if (view.ShowDialog() == true)
            {
                if (manager.GetFile(view.txtFileName.Text) == null)
                {
                    if (manager.GetFilePath(view.lblFilePath.Text) == null)
                    {
                        if (manager.Add(vm.File) > 0)
                        {
                            vm.FilePath = view.lblFilePath.Text.ToString();
                            vm.EMail = App.User.EMail;
                            vm.Situation = Situations.Accessible;
                            //vm.FileOrFolder = view.cbxFileOrFolder.SelectedIndex;
                            Items.Add(vm);
                        }
                        else
                            MessageBox.Show("Ekleme yapılamadı...");
                    }
                    else
                        MessageBox.Show("Bu dosya yolu zaten kullanılıyor.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Bu dosya adı zaten kullanılıyor.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void OnDelete(object parameter)
        {
            FileViewModel vm = parameter as FileViewModel;
            if (MessageBox.Show("Dosyayı kaldırmak istiyor musunuz?", "Dosya Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (manager.Remove(vm.Id) > 0)
                {
                    Items.Remove(vm);
                }
                else
                    MessageBox.Show("Silinemedi...");
            }
        }

        private void OnUpdate(object parameter)
        {
            FileViewModel vm = parameter as FileViewModel;
            string oldFileName = vm.File.FileName;
            SecurityWindow view = new SecurityWindow(vm.FilePath, vm.FileOrFolder.ToString(), vm.Situation.ToString(), vm.SecurityMode.ToString()) { DataContext = vm };

            if (view.txtSituation.Text == "Accessible")
            {
                vm.EMail = App.User.EMail;
                vm.FilePath = view.lblFilePath.Text;

                if (view.txtFileOrFolder.Text == "Folder")
                {
                    vm.SecurityMode = SecurityModes.Hidden;
                    view.cbxSecurityModes.SelectedValue = SecurityModes.Hidden;
                    view.cbxSecurityModes.IsEnabled = false;
                }

                if (view.ShowDialog() == true)
                {
                    if (manager.Update(oldFileName, vm.File) == 0)
                        MessageBox.Show("Güncelleme Yapılamadı...");
                    else
                    {
                        vm.Situation = Situations.Safe;
                        vm = new FileViewModel(manager.GetFile(vm.FileName));
                    }
                }
            }
            else
            {
                MessageBox.Show("Bu dosya zaten yeteri kadar korunuyor. Daha fazla şifrelemek veya gizlemek dosyanın içeriğini bozabilir.", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void OnSolve(object parameter)
        {
            FileViewModel vm = parameter as FileViewModel;
            if (vm.Situation == Situations.Safe)
            {
                string oldFileName = vm.File.FileName;
                SecurityView securityView = new SecurityView();

                if (manager.Update(oldFileName, vm.File) == 0)
                    MessageBox.Show("Çözüm Yapılamadı...");
                else
                {
                    vm.Situation = Situations.Accessible;
                    vm.SecurityMode = SecurityModes.Null;
                    vm = new FileViewModel(manager.GetFile(vm.FileName));
                }
            }
            else
            {
                MessageBox.Show("Dosya zaten erişime açık.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
