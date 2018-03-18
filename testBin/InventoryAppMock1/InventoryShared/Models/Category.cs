﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryShared.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
        //A basic description of the catagory.
        [StringLength(50)]
        public string Info { get; set; }
        //A reference to what the catagory is.
        [StringLength(20)]
        public string Ref { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
