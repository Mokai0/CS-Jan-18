using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.Database.Log = (message) => Debug.WriteLine(message);

                var comicBookId = 1;

                //var comicBook1 = context.ComicBooks.Find(comicBookId);
                //var comicBook2 = context.ComicBooks.Find(comicBookId);

                var comicBook = context.ComicBooks
                    //.Where(cb => cb.Id == comicBookId) becomes redundant when used with the following commands:
                    .SingleOrDefault(cb => cb.Id == comicBookId);
                    //'SingleOrDefault' will return a single entity or a null depending on whether an item is found matching the provided filter criteria. If more than one result is found an exception is thrown.
                    //'FirstOrDefault' on the other hand won't throw an exception.
                    //'Single' or 'First' go a step further throwing an exception if no results are found.

                ////////////////////////////////////////////////////////////////

                ////var comicBooks = context.ComicBooks
                ////    .Include(cb => cb.Series)
                ////    .OrderByDescending(cb => cb.IssueNumber)
                ////    .ThenBy(cb => cb.PublishedOn)
                ////    .ToList();

                //var comicBooksQuery = context.ComicBooks
                //    .Include(cb => cb.Series)
                //    .OrderByDescending(cb => cb.IssueNumber);
                ////since the Parent query contains this OrderBy clause the child queries will contain an OrderBy clause as well

                //var comicBooks = comicBooksQuery.ToList();

                //var comicBooks2 = comicBooksQuery
                //    .Where(cb => cb.AverageRating < 7)
                //    .ToList();

                //foreach (var comicBook in comicBooks)
                //{
                //    Console.WriteLine(comicBook.DisplayText);
                //}

                //Console.WriteLine();
                //Console.WriteLine("# of comic books: {0}", comicBooks.Count);
                //Console.WriteLine();

                //foreach (var comicBook in comicBooks2)
                //{
                //    Console.WriteLine(comicBook.DisplayText);
                //}

                //Console.WriteLine();
                //Console.WriteLine("# of comic books: {0}", comicBooks2.Count);

                //////////////////////////////////////////////////////////////////////

                ////var comicBooks = context.ComicBooks
                ////.Include(cb => cb.Series)
                ////.Include(cb => cb.Artists.Select(a => a.Artist))
                ////.Include(cb => cb.Artists.Select(a => a.Role))
                ////.ToList();
                ////foreach (var comicBook in comicBooks)
                ////{
                ////    var artistRoleNames = comicBook.Artists
                ////        .Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                ////    var artistRolesDisplayText = string.Join(", ", artistRoleNames);

                ////    Console.WriteLine(comicBook.DisplayText);
                ////    Console.WriteLine(artistRolesDisplayText);
                ////}

                //Console.ReadLine();

            }
        }
    }
}
