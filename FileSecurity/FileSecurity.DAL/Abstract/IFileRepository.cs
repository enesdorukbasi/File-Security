using FileSecurity.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSecurity.DAL.Abstract
{
    public interface IFileRepository : IRepository<File>
    {
        IEnumerable<File> GetAllWithUser(string eMail);
        File GetFile(string fileName);
    }
}
