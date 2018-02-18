using ConsoleEFtesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleEFtesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var brand1 = new Brand()
            {
                BrandName = "Ziyad"
            };

            var item1 = new Item()
            {
                Brand = brand1,
                ProductName = "hummus",
                Size = 12,
                Unit = "Oz",
                Cases = 10,
                Cost = 22.29,
                Expiration = DateTime.Today
                //Set only for now, will change later
            };
        }
    }
}
