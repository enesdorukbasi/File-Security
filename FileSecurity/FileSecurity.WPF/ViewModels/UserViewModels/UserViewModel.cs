using FileSecurity.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSecurity.WPF.ViewModels.UserViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private User _user;
        
        public User User
        {
            get { return _user; }
        }

        public string EMail
        {
            get { return _user.EMail; }
            set
            {
                if(_user.EMail != value)
                {
                    _user.EMail = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get { return _user.Password; }
            set
            {
                if (_user.Password != value)
                {
                    _user.Password = value;
                    OnPropertyChanged();
                }
            }
        }

        public string UserName
        {
            get { return _user.UserName; }
            set
            {
                if(_user.UserName != value)
                {
                    _user.UserName = value;
                    OnPropertyChanged();
                }
            }
        }

        public UserViewModel() : this(new User()) { }
        public UserViewModel(User user)
        {
            this._user = user;
        }
    }
}
