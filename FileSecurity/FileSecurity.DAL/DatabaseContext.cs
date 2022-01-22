using FileSecurity.EL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSecurity.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<File> Files { get; set; }

        public DatabaseContext() : base("FileSecurityDB")
        {
            Database.SetInitializer<DatabaseContext>(new DropCreateDatabaseAlways<DatabaseContext>());
        }
    }
}
