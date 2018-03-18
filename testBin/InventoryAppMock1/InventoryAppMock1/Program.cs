using InventoryShared;
using InventoryShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace InventoryAppMock1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.Database.Log = (message) => Debug.WriteLine(message);

                var productId = 1;

                //var product1 = context.Products.Find(productId);
                //var product2 = context.Products.Find(productId);

                var product = context.Products
                    //.Where(p => p.Id == productId)
                    //.SingleOrDefault();
                    //Same as this:
                    .SingleOrDefault(p => p.Id == productId);



                //var products = context.Products
                //    .Include(p => p.Brand)
                //    .Include(p => p.Category)
                //    //.Where(p => p.ProductName.Contains("beans"))
                //    //.Where(p => p.Category.Ref == "Can" || p.Brand.Name == "Ziyad")
                //    .OrderBy(p => p.Quantity)
                //    .ThenBy(p => p.Category)
                //    .ToList();

                //foreach (var product in products)
                //{
                //    Console.WriteLine(product.ItemInfo);
                //}


                //Query using Linq
                //var productsQuery = from p in context.Products select p;
                //var products = productsQuery.ToList();

                //Console.WriteLine("# of products: {0}", products.Count);

                //var products = context.Products
                //    //These are needed because they are foreign key properties
                //    .Include(p => p.Brand)
                //    .Include(p => p.Category)
                //    .ToList();

                //foreach (var product in products)
                //{
                //    Console.WriteLine(product.ItemInfo);
                //}

                Console.ReadLine();
            }
        }
    }
}
