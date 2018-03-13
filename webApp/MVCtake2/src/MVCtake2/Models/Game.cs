using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtake2.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string[] Developers { get; set; }
        public bool Favorite { get; set; }
    }
}