using InventoryAppMock1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppMock1
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
        }

        public DbSet<Product> Products { get; set; }
    }
}
