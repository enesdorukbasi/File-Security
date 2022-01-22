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
    public class FileRepository : Repository<File>, IFileRepository
    {
        public FileRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<File> GetAllWithUser(string eMail)
        {
            return context.Set<File>().Include(x =>x.User).Where(x => x.EMail == eMail).ToList();
        }

        public File GetFile(string fileName)
        {
            return context.Set<File>().FirstOrDefault(x => x.FileName.Equals(fileName));
        }

        public File GetFilePath(string filePath)
        {
            return context.Set<File>().FirstOrDefault(x => x.FilePath.Equals(filePath));
        }
    }
}
