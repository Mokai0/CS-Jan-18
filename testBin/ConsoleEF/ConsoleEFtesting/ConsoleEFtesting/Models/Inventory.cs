using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEFtesting.Models
{
    class Inventory
    {
        public Inventory()
        {
            
        }

        public int Id { get; set; }
        public int ItemId { get; set; }

        public Item Item { get; set; }
        //This should retrieve the Item(Product) associated with the Product

        public string DisplayText
        {
            get
            {
                return $"{Item?.Brand.BrandName} {Item.ProductName}";
            }
        }
    }
}
