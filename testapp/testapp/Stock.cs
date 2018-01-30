using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testapp
{
    class Stock
    {
        //public bool HowOld(Invoice ExpDate)
        //{
        //    return ExpDate - '2 Months before current date';
        //    //This is not a certainty but I think so long as the result of an arithmatic value is positive it is true and once it becomes 0 or negative it becomes false.
        //}

        //Use 'get' and 'set' here to retrieve the current stockpile of inventory as well as selectively update it.

        //Will probably use a List for this, not sure yet.
        //Also look into IEnumerable.
        //Think about using 'HashSet's as they allow you the option of retrieving a hash code for a specific property:
        //   An example would be the combined string for a item's Name being "Brand + Product + Size" would produce a unique hash code for each and every item.
        //   This inturn could be useful for tracking down that specific item once the new Invoice has been completed so as to update the new quantity in Stock.
    }
}
