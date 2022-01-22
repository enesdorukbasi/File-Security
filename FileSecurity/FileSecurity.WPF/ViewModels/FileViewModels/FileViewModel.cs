using FileSecurity.EL;
using FileSecurity.WPF.Views.MainViewInner;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSecurity.WPF.ViewModels.FileViewModels
{
    public class FileViewModel : BaseViewModel
    {
        private File _file;
        FileWindow view = new FileWindow();
        public File File
        {
            get { return _file; }
        }

        public int Id
        {
            get { return _file.Id; }
            set
            {
                if (_file.Id != value)
                {
                    _file.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string FileName
        {
            get { return _file.FileName; }
            set
            {
                if (_file.FileName != value)
                {
                    _file.FileName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string FilePath
        {
            get { return _file.FilePath; }
            set
            {
                if (_file.FilePath != value)
                {
                    _file.FilePath = value;
                    OnPropertyChanged();
                }
            }
        }

        public string EMail
        {
            get { return _file.EMail; }
            set
            {
                if (_file.EMail != value)
                {
                    _file.EMail = value;
                    OnPropertyChanged();
                }
            }
        }

        public SecurityModes SecurityMode
        {
            get { return _file.SecurityMode; }
            set
            {
                if (_file.SecurityMode != value)
                {
                    _file.SecurityMode = value;
                    OnPropertyChanged();
                }
            }
        }

        public Situations Situation
        {
            get { return _file.Situation; }
            set
            {
                if(_file.Situation != value)
                {
                    _file.Situation = value;
                    OnPropertyChanged();
                }
            }
        }

        public FileOrFolders FileOrFolder
        {
            get { return _file.FileOrFolder; }
            set
            {
                if (_file.FileOrFolder != value)
                {
                    _file.FileOrFolder = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<SecurityModes> securityModes;
        public ObservableCollection<SecurityModes> SecurityModes
        {
            get { return securityModes; }
            set
            {
                if (securityModes != value)
                {
                    securityModes = value;
                    OnPropertyChanged();
                }
            }
        }


        private ObservableCollection<Situations> situations;
        public ObservableCollection<Situations> Situations
        {
            get { return situations; }
            set
            {
                if (situations != value)
                {
                    situations = value;
                    OnPropertyChanged();
                }
            }
        }


        private ObservableCollection<FileOrFolders> fileOrFolders;
        public ObservableCollection<FileOrFolders> FileOrFolders
        {
            get { return fileOrFolders; }
            set
            {
                if (fileOrFolders != value)
                {
                    fileOrFolders = value;
                    OnPropertyChanged();
                }
            }
        }

        public FileViewModel() : this(new File()) { }
        public FileViewModel(File file)
        {
            this._file = file;
            file.EMail = App.User.EMail;
            securityModes = new ObservableCollection<SecurityModes> { EL.SecurityModes.Encrypted, EL.SecurityModes.Hidden, EL.SecurityModes.EncryptedAndHidden};
            situations = new ObservableCollection<Situations> { EL.Situations.Safe, EL.Situations.Accessible };
            fileOrFolders = new ObservableCollection<FileOrFolders> { EL.FileOrFolders.File, EL.FileOrFolders.Folder };
        }
    }
}
