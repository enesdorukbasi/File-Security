using FileSecurity.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSecurity.DAL
{
    public class UnitOfWork : IDisposable
    {
        private DatabaseContext context;

        private UserRepository user_repo;
        private FileRepository file_repo;

        public UserRepository UserRepo
        {
            get
            {
                if (user_repo == null)
                    user_repo = new UserRepository(context);
                return user_repo;
            }
        }

        public FileRepository FileRepo
        {
            get
            {
                if (file_repo == null)
                    file_repo = new FileRepository(context);
                return file_repo;
            }
        }

        public UnitOfWork()
        {
            context = new DatabaseContext();
        }

        public int Save()
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    int adet = context.SaveChanges();
                    transaction.Commit();
                    return adet;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public void Dispose()
        {
            user_repo?.Dispose();
            file_repo?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
