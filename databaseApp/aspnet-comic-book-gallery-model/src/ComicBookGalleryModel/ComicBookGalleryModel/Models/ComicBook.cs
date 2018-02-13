using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class ComicBook
    {
        public ComicBook()
        {
            Artists = new List<Artist>();
        }

        public int Id { get; set; }
        public int SeriesId { get; set; }
        //By following the convention of 'NavigationPropertyName + PrinciplePrimaryKeyName' EF will detect and determine this as a foreign key property. If I didn't want to use convention and still get the same result I'd use the following, coupled with the appropriate using statement:
        //[ForeignKey("SeriesNonConvenId")]
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public double? AverageRating { get; set; }

        public Series Series { get; set; }
        //It's a good idea to seperate Nav properties from other properties so that they are easily identifiable.
        public ICollection<Artist> Artist { get; set; }

        public string DisplayText
        {
            get
            {
                return $"{Series?.Title} #{IssueNumber}";
            }
        }

        public List<Artist> Artists { get; }
    }
}
