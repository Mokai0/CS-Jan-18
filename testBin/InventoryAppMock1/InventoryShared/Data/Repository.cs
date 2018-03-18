using InventoryShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace InventoryShared.Data
{
    //This class should handle the various CRUD operations handling
    public static class Repository
    {
        //<summary> Private method that returns a db context to the class
        //<returns> An instance of the context class
        static Context GetContext()
        {
            var context = new Context();
            context.Database.Log = (message) => Debug.WriteLine(message);
            return context;
        }
    }
}
