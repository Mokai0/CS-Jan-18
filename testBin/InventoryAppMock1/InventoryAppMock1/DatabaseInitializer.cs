using InventoryAppMock1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace InventoryAppMock1
{
    internal class DatabaseInitializer
        : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            var Ziyad = new Brand() { Name = "Ziyad" };
            var Cortas = new Brand() { Name = "Cortas" };
            var Tazah = new Brand() { Name = "Tazah" };

            var Dry = new Category() { Info = "Dried Foods" };
            var Can = new Category() { Info = "Canned Foods" };
            var Dairy = new Category() { Info = "Dairy Foods" };
            var Spice = new Category() { Info = "Spices" };
            var Frozen = new Category() { Info = "Frozen Foods" };

            context.Products.Add(new Product()
            {
                Brand = Ziyad,
                ProductName = "Okra Zero",
                Quantity = 5,
                Category = Frozen
            });
            context.Products.Add(new Product()
            {
                Brand = Ziyad,
                ProductName = "Fava Beans",
                Quantity = 3,
                Category = Dry
            });
            context.Products.Add(new Product()
            {
                Brand = Cortas,
                ProductName = "Hummus",
                Quantity = 12,
                Category = Can
            });
            context.Products.Add(new Product()
            {
                Brand = Cortas,
                ProductName = "Fava Beans",
                Quantity = 1,
                Category = Can
            });
            context.Products.Add(new Product()
            {
                Brand = Tazah,
                ProductName = "Hummus",
                Quantity = 2,
                Category = Can
            });
            context.Products.Add(new Product()
            {
                Brand = Tazah,
                ProductName = "Fava Beans",
                Quantity = 8,
                Category = Can
            });
            context.SaveChanges();
        }
    }
}
