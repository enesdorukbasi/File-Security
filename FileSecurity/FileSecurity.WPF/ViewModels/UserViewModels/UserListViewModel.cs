using FileSecurity.BL;
using FileSecurity.EL;
using FileSecurity.WPF.Commands;
using FileSecurity.WPF.Views;
using FileSecurity.WPF.Views.MainViewInner;
using FileSecurity.WPF.Views.MainViews;
using FileSecurity.WPF.Views.UserViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FileSecurity.WPF.ViewModels.UserViewModels
{
    public class UserListViewModel : BaseViewModel
    {
        private UserManager manager;

        private ObservableCollection<UserViewModel> _items;
        private UserViewModel _selectedItem;

        public ObservableCollection<UserViewModel> Items
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

        public UserViewModel SelectedItem
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

        public UserListViewModel()
        {
            manager = new UserManager();
            OnRefresh();

            RefreshCommand = new RelayCommand(o => { OnRefresh(); }, o => { return true; });
            InsertCommand = new RelayCommand(o => { OnInsert(); }, o => { return true; });
            DeleteCommand = new RelayCommand((parameter) => { OnDelete(parameter); }, o => { return _selectedItem != null; });
            UpdateCommand = new RelayCommand((parameter) => { OnUpdate(); }, o => { return true; });
        }

        private void OnRefresh()
        {
            Items = new ObservableCollection<UserViewModel>();
            List<User> users = manager.List();
            foreach (var item in users)
            {
                Items.Add(new UserViewModel(item));
            }
        }

        private void OnInsert()
        {
            UserViewModel vm = new UserViewModel();
            SignInView view = new SignInView() { DataContext = vm };
            LoginView loginView = new LoginView();
            if (view.ShowDialog() == true)
            {
                if (manager.Add(vm.User) > 0)
                {
                    Items.Add(vm);
                    loginView.Show();
                }
                else
                {
                    MessageBox.Show("Ekleme Yapılamadı.");
                }
            }
        }

        private void OnDelete(object parameter)
        {
            UserViewModel vm = parameter as UserViewModel;
            if (MessageBox.Show(vm.EMail + " mail adresine sahip kullanıcıyı silmek istiyor musunuz?", "Kullanıcı Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (manager.Remove(vm.EMail) > 0)
                {
                    Items.Remove(vm);
                }
                else
                    MessageBox.Show("Silinemedi.");
            }
        }

        private void OnUpdate()
        {
            SettingsView settingsView = new SettingsView();
            object parameter = manager.GetUser(settingsView.txtUserMail.Text);
            UserViewModel vm = parameter as UserViewModel;
            string oldEMail = settingsView.txtUserMail.Text;
            UserUpdateWindow view = new UserUpdateWindow { DataContext = manager.GetUser(settingsView.txtUserMail.Text) };

            if (view.ShowDialog() == true)
            {
                if (manager.Update(oldEMail, manager.GetUser(settingsView.txtUserMail.Text)) == 0)
                {
                    MessageBox.Show("Güncelleme Yapılamadı.");
                }
            }
        }
    }
}
