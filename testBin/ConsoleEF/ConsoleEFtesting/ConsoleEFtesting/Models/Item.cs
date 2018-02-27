using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEFtesting.Models
{
    class Item
    {
        public Item()
        {
            Inventorys = new List<Inventory>();
        }

        public int BrandId { get; set; }
        public string ProductName { get; set; }
        public double Size { get; set; }
        public string Unit { get; set; }
        public double Cases { get; set; }
        public double Cost { get; set; }
        public DateTime Expiration { get; set; }

        public Brand Brand { get; set; }
        //This will retrieve the Brand associated with the product
        public ICollection<Inventory> Inventorys { get; set; }
    }
}
