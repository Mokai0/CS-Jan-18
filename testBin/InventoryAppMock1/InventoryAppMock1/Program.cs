using InventoryShared;
using InventoryShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace InventoryAppMock1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {

                var products = context.Products
                    .Include(p => p.Brand)
                    //if this wasn't here the brand wouldn't be included
                    .Include(p => p.Category)
                    .ToList();
                foreach (var product in products)
                {
                    Console.WriteLine(product.ItemInfo);
                }

                //Console.ReadLine();
            }
        }
    }
}
