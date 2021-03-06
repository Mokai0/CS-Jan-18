﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StockWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        [Required, StringLength(100)]
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int MyProperty { get; set; }

        public Brand Brand { get; set; }
        public Category Category { get; set; }
        //public ICollection<Category> Categorys { get; set; }
        //One to many not many to many


        /// <summary>
        /// Text Display functions follow
        /// </summary>
        public string ItemTag
        {
            get
            {
                return $"{Brand.Name} {ProductName}";
            }
        }
    }
}