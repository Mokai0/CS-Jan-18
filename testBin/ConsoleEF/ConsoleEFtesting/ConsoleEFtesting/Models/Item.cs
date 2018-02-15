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
            
        }

        public string ProductName { get; set; }
        public double Size { get; set; }
        public string Unit { get; set; }
        public double Cases { get; set; }
        public double Cost { get; set; }
        public DateTime Expiration { get; set; }

    }
}
