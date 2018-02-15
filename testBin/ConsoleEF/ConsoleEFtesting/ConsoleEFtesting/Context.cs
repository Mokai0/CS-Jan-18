using ConsoleEFtesting.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEFtesting
{
    class Context : DbContext
    {
        public Context()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
        }

        public DbSet<Inventory> Inventorys { get; set; }
    }
}
