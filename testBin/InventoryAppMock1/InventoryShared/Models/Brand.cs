using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryShared.Models
{
    public class Brand
    {
        public Brand()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
        [StringLength(25)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
        //This is put here because a Brand can be associated with more than one Product
    }
}
