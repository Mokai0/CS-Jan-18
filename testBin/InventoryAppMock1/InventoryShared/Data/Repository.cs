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

        //<summary> Returns a count of the products.
        //<returns> An integar count of the products.
        public static int GetProductCount()
        {
            using (Context context = GetContext())
            {
                return context.Products.Count();
            }
        }

        //<summary> Returns a list of products ordered by Brand (as this would correlate to what distributer I'd need to consult) then by Catagory (because this way I could go through each section of the store for the respective distributer without the need for doubling back).
        //<returns> An IList collection of Product entity instances.
        public static IList<Product> GetProducts()
        {
            using (Context context = GetContext())
            {
                return context.Products
                    .Include(p => p.Brand)
                    .Include(p => p.Category)
                    .OrderBy(p => p.Brand.Name)
                    .ThenBy(p => p.Category.Ref)
                    .ThenBy(p => p.ProductName)
                    .ToList();
            }
        }
    }
}
