using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class ComicBook
    {
        public int Id { get; set; }
        //If the class contains a property named Id, a primary key column with the same name and data type will be added to the entity's database table. Because we're using a numeric data type, EF will also make the column an identity column. Identity columns are automatically assigned values by the database when new records are added to the table. Primary key properties, can also be named:
        //"ID" "ClassNameId" or "ClassNameID"

        public string SeriesTitle { get; set; }
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
    }
}
