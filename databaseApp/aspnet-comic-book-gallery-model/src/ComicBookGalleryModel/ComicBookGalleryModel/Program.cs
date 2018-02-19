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

                //var comicBooks = context.ComicBooks
                //    .Include(cb => cb.Series)
                //    .OrderByDescending(cb => cb.IssueNumber)
                //    //.OrderBy(cb => cb.PublishedOn)
                //    //When called the last 'OrderBy' operation will be used
                //    .ThenBy(cb => cb.PublishedOn)
                //    .ToList();

                //var comicBooksQuery = context.ComicBooks
                //    .Include(cb => cb.Series)
                //    .OrderByDescending(cb => cb.IssueNumber);
                //    //since the Parent query contains this OrderBy clause the child queries will contain an OrderBy clause as well

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







                var comicBooks = context.ComicBooks
                //.Include(cb => cb.Series)
                //.Include(cb => cb.Artists.Select(a => a.Artist))
                //.Include(cb => cb.Artists.Select(a => a.Role))
                .ToList();
                foreach (var comicBook in comicBooks)
                {
                    if (comicBook.Series == null)
                    {
                        context.Entry(comicBook)
                            //The 'Entry' method returns a Db Entity Entry Object for the referenced entity. Every entity that has been materialized and tracked by the context has a Db Entity Entry Object associated with it. - Basically once it's been pulled by EF and being used it has a 'key' association that can be used to track and manipulate it.
                            //.Collection
                            //'Collection' doesn't work here since the Series property is a non-collection navigation property
                            .Reference(cb => cb.Series)
                            .Load();
                            //The Load method will execute a query against the database everytime its called regardless if the necessary info is loaded or not. This means it should almost always be called within a conditional statement.
                    }

                    var artistRoleNames = comicBook.Artists
                        .Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                    var artistRolesDisplayText = string.Join(", ", artistRoleNames);

                    Console.WriteLine(comicBook.DisplayText);
                    Console.WriteLine(artistRolesDisplayText);
                }

                Console.ReadLine();

            }
        }
    }
}
