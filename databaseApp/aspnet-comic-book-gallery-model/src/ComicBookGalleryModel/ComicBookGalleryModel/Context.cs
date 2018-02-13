using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel
{
    public class Context : DbContext
    {
        //Method #1 for renaming and instantiating a db
        //public  Context() : base("ComicBookGallery") {}

        //Method #2 
        //public Context() : base("Data Source=(localdb)" +
        //    @"\MSSQLLocalDB;Initial Catalog=ComicBookGallery;" +
        //    //Note the '@' this tells the compiler to interperet the next line of code as a string literal instead of a string. This is needed here because '\' is used to break the following text out of the string format. Another method to remedy this would be to add a second '\' which would tell the compiler to not read this '\' as a break in the string, like this:
        //    //"\\MSSQLLocalDB;Initial Catalog=ComicBookGallery;"
        //    "Integrated Security=True;MultipleActiveResultSets=True")
        //{ }

        public DbSet<ComicBook> ComicBooks { get; set; }
    }
}
