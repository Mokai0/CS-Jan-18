using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEFtesting.Models
{
    class Inventory

        //revert this
        //look up some examples of this

    {
        public Inventory()
        {
            
        }

        public int Id { get; set; }
        public int ItemId { get; set; }

        public ICollection<Item> Item { get; set; }
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
