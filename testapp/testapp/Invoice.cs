using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testapp
{
    class Invoice
    {
        //adding a 'readonly' tag would lock the information in place so as not to be changed after it has been created but I think I'll keep it flexible for now.
        //example 'public readonly int Size' would make sense but sometimes manufacturers will adjust the size a bit to keep costs down.
        public string   Brand;
        public string   Product;
        public int      Size;
        //These three variables will be combined to construct the name of the item.
        public int      Received;
        //This variable will represent the quantity of said item that has been received, "how many cases".
        public int      Cost;
        //Cost per case.
        //public DateTime ExpDate;
        //When the new product will expire - this variable object might give me trouble later so I'll omit it for now.
        public double   MarkUp;
        //This should be the 1 + a percentage, 1.39 is a 39% mark up.

        public Invoice(string brand, string product, int size, int received, int cost, double markup)
        {
            Brand = brand;
            Product = product;
            Size = size;
            Received = received;
            Cost = cost;
            MarkUp = markup;
        }
    }
}
