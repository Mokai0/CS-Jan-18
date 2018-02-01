using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testapp
{
    class Invoice
    {
        //public var Item;
        //This will become the actual Item object in which all of the following objects will be assigned to. I don't know how to create this yet. An instance of this object should be considered the overseer of all the information for each actual item that would have been received on an invoice. This information should be collected and formatted through the use of the 'Invoice()' constructor located below - the name of which might change.

        //adding a 'readonly' tag would lock the information in place so as not to be changed after it has been created but I think I'll keep it flexible for now.
        //example 'public readonly int Size' would make sense but sometimes manufacturers will adjust the size a bit to keep costs down.
        public string   Brand { get; set; }
        public string   Product { get; set; }
        public double   Size { get; set; }
        //These three variables will be combined to construct the name of the item.
        public double   Received { get; set; }
        //This variable will represent the quantity of said item that has been received, "how many cases".
        public double   Cost { get; set; }
        //Cost per case.
        //public DateTime ExpDate { get; set; }
        //When the new product will expire - this variable object might give me trouble later so I'll omit it for now.
        public double   MarkUp { get; set; }
        //This should be the 1 + a percentage, 1.39 is a 39% mark up.

        public Invoice(string brand, string product, double size, double received, double cost, double markup)
            //The name of this constructor might chang to 'Item' for readablity and contextual congruity.
        {
            Brand = brand;
            Product = product;
            Size = size;
            //Above 3 will comprise the "Name"; haven't decided on whether I'll concatonate them or keep them seperate
            Received = received;
            //Quantity so an int initially but I'm thinking a double considering the times we've received half cases
            Cost = cost;
            //This will be a double
            MarkUp = markup;
            //Also a double
        }
    }
}
