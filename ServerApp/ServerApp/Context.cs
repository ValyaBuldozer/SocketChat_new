using System.Data.Entity;
using DbLibrary;

namespace ServerApp
{
    class Context: DbContext
    {
        public Context ():base ("UsersAndMessages") { }

        DbSet<User> Users { set; get; }
        DbSet<DbMessage> Messages { set; get; }
    }
}
