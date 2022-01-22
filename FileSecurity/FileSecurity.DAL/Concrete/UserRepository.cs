using FileSecurity.DAL.Abstract;
using FileSecurity.EL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSecurity.DAL.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public bool Login(string eMail, string password)
        {
            return (context.Set<User>().FirstOrDefault(x => x.EMail.ToLower().Equals(eMail.ToLower()) && x.Password.Equals(password)) != null);
        }
    }
}
