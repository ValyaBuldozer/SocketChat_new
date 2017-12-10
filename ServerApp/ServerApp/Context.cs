using System.Data.Entity;

namespace ServerApp
{
    class Context: DbContext
    {
        public Context ():base ("DbConnection") { }

        public DbSet<User> Users { set; get; }
        //public DbSet<DbMessage> Messages { set; get; }
    }
}
