using FileSecurity.DAL;
using FileSecurity.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSecurity.BL
{
    public class FileManager : IDisposable
    {
        private UnitOfWork work;

        public FileManager()
        {
            work = new UnitOfWork();
        }

        public List<File> ListWithUser(string eMail)
        {
            return work.FileRepo.GetAllWithUser(eMail).ToList();
        }

        public List<File> List()
        {
            return work.FileRepo.GetAll().ToList();
        }

        public File GetFile(int id)
        {
            return work.FileRepo.GetItem(id);
        }

        public File GetFile(string fileName)
        {
            return work.FileRepo.GetFile(fileName);
        }

        public File GetFilePath(string filePath)
        {
            return work.FileRepo.GetFilePath(filePath);
        }

        public int Update(string oldFileName, File file)
        {
            if (file.FileName != oldFileName)
            {
                if (work.FileRepo.GetItem(file.FileName) != null)
                    throw new ArgumentException(file.FileName + " adlı dosya zaten var...");
            }
            work.FileRepo.Update(file);
            return work.Save();
        }

        public int Add(File file)
        {
            work.FileRepo.Add(file);
            return work.Save();
        }

        public int Remove(int id)
        {
            work.FileRepo.Remove(id);
            return work.Save();
        }

        public int Remove(File file)
        {
            work.FileRepo.Remove(file);
            return work.Save();
        }

        public void Dispose()
        {
            work?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
