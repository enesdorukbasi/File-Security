using FileSecurity.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSecurity.DAL.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        bool Login(string eMail, string password);
    }
}
