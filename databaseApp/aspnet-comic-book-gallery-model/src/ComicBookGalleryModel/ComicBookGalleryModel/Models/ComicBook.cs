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
        public Series Series { get; set; }
        //EF will now refer to the 'Series' property as a navigation property as it allows us to navigate the ComicBook entity to the Series entity. This means that the 'Series' is now dependent upon the 'ComicBook'.
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public double? AverageRating { get; set; }

        public string DisplayText
        {
            get
            {
                return $"{Series?.Title} #{IssueNumber}";
                //This is called an interpolated string - it allows the mixing of code expressions with text.
            }
        }
    }
}
