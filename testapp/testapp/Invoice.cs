using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testapp
{
    class Invoice
    {
        public string   Brand;
        public string   Product;
        public int      Size;
        //These three variables will be combined to construct the name of the item.
        public int      Recieved;
        //This variable will represent the quantity of said item that has been recieved, "how many cases".
        public int      Cost;
        //Cost per case.
        //public DateTime ExpDate;
        //When the new product will expire - this variable object might give me trouble later so I'll omit it for now.
        public double   MarkUp;
        //This should be the 1 + a percentage, 1.39 is a 39% mark up.

        Invoice(string brand, string product, int size, int recieved, int cost, double markup)
        {
            Brand = brand;
            Product = product;
            Size = size;
            Recieved = recieved;
            Cost = cost;
            MarkUp = markup;
        }
    }
}
