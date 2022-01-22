using FileSecurity.DAL;
using FileSecurity.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSecurity.BL
{
    public class UserManager : IDisposable
    {
        public string oldUserMail = "";
        private UnitOfWork work;

        public UserManager()
        {
            work = new UnitOfWork();
        }

        public bool Login(string eMail, string password)
        {
            oldUserMail = eMail;
            return work.UserRepo.Login(eMail, password);
        }

        public List<User> List()
        {
            return work.UserRepo.GetAll().ToList();
        }

        public User GetUser(string eMail)
        {
            return work.UserRepo.GetItem(eMail);
        }

        public int Add(User user)
        {
            if (work.UserRepo.GetItem(user.EMail) != null)
                throw new ArgumentException(user.EMail + " bu mail adresine sahip kullanıcı zaten var.");
            work.UserRepo.Add(user);
            return work.Save();
        }

        public int Remove(User user)
        {
            work.UserRepo.Remove(user);
            return work.Save();
        }

        public int Remove(string eMail)
        {
            work.UserRepo.Remove(eMail);
            return work.Save();
        }

        public int Update(string oldUserEmail, User user)
        {
            if(user.EMail != oldUserEmail)
            {
                if (work.UserRepo.GetItem(user.EMail) != null)
                    throw new ArgumentException(user.EMail + " bu mail adresine sahip kullanıcı zaten var.");
            }
            work.UserRepo.Update(user);
            return work.Save();
        }

        public void Dispose()
        {
            work?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
