using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    //[Table("Talent")]
    //This will rename the Artist table asthetically
    public class Artist
    {
        public Artist()
        {
            ComicBooks = new List<ComicBookArtist>();
        }

        public int Id { get; set; }
        [Required, StringLength(50)]
        //[Column("FullName")]
        //This will rename the Artist's Name Column asthetically
        public string Name { get; set; }

        public ICollection<ComicBookArtist> ComicBooks { get; set; }
    }
}
