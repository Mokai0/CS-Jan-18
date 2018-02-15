using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEFtesting.Models
{
    class Brand
    {
        public Brand()
        {
            Inventorys = new List<Inventory>();
        }

        public int Id { get; set; }
        public string BrandName { get; set; }

        public ICollection<Inventory> Inventorys { get; set; }
    }
}
