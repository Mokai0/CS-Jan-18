using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEFtesting
{
    class DatabaseInitializer
        : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            var brand1 = new    Brand()
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
                Expiration = "1/1/2020"
                //Set only for now, will change later
            };
            context.SaveChanges();
        }
    }
}
