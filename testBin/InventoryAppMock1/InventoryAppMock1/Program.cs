using InventoryAppMock1.Models;
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
                context.Products.Add(new Product()
                {
                    Brand = new Brand()
                    {
                        Name = "Ziyad"
                    },
                    ProductName = "Hummus",
                    Quantity = 3,
                    ExpirationDate = DateTime.Today
                });
                context.SaveChanges();

                var products = context.Products
                    .Include(p => p.Brand)
                    //if this wasn't here the brand wouldn't be included
                    .ToList();
                foreach (var product in products)
                {
                    Console.WriteLine(product.Brand.Name);
                }

                //Console.ReadLine();
            }
        }
    }
}
