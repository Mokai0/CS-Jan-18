using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppMock1.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
        //Allow nullability
        public string Catagory { get; set; }

        [Required]
        public Brand Brand { get; set; }

    }
}
