using InventoryAppMock1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Brand = "Ziyad",
                    ProductName = "Hummus",
                    Quantity = 3,
                    ExpirationDate = DateTime.Today
                });
                context.SaveChanges();

                var products = context.Products.ToList();
                foreach (var product in products)
                {
                    Console.WriteLine(product.ProductName);
                }

                //Console.ReadLine();
            }
        }
    }
}
