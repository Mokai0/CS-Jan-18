using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppMock1.Models
{
    public class Brand
    {
        public Brand()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
        //This is put here because a Brand can be associated with more than one Product
    }
}
