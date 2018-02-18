using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class ComicBookArtist
    {
        public int Id { get; set; }
        public int ComicBookId { get; set; }
        //This is a foreign key property to the comicbook that we're adding artists to
        public int ArtistId { get; set; }
        //This is a foreign key property to each artist that will be added to the comic book
        public int RoleId { get; set; }
        //Belongs to artist's role, also a foreign key property

        //Naviigation properties
        public ComicBook ComicBook { get; set; }
        public Artist Artist { get; set; }
        public Role Role { get; set; }
    }
}
