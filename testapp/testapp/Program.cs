﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testapp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("What do you want to do?");

            var Menu = "1] See current Stock \n2] Create a new Invoice" + Environment.NewLine; // + "3] Check invoice History";
                                                                                               //In the above line of code "\n" and "Environment.NewLine" serve the same function however while \n is much shorter Environment.NewLine is supposedly more context correct/savvy. 
                                                                                               //Need to focus on a Minimum Viable Product for now, can add History later.

            //Console.WriteLine(Menu);

            //         string selection = Console.ReadLine();
            //         if ( selection == "1")
            //         {
            //             Console.WriteLine("You've selected to see your current Stock.");
            //         }
            //         else if( selection == "2")
            //         {
            //             Console.WriteLine("You've selected to create a new Invoice.");
            //         }
            //         else if( selection == "3")
            //         {
            //             Console.WriteLine("You've selected to see your invoice History.");
            //         }
            //         else
            //         {
            //             Console.WriteLine("You didn't pick a valid option");
            //         }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////


            //Console.WriteLine("Create an item? Type yes to continue; type anything else to quit.");

            //while (true)
            //{
            //    string Answer = Console.ReadLine().ToLower();

            //    if(Answer == "yes")
            //    {
            //        Console.Write("Enter a Brand: ");
            //        string brand = Console.ReadLine().ToUpper();
            //        Console.Write("What is the product called: ");
            //        string product = Console.ReadLine().ToUpper();
            //        Console.Write("What is the size (in grams or mL): ");
            //        double size = double.Parse(Console.ReadLine());
            //        Console.Write("How many cases came in: ");
            //        double received = double.Parse(Console.ReadLine());
            //        Console.Write("What's the cost of a case: ");
            //        double cost = double.Parse(Console.ReadLine());

            //        Console.WriteLine("Here's your item:");
            //        Invoice item = new Invoice(brand, product, size, received, cost);
            //        Console.WriteLine(item.Brand + " " 
            //                        + item.Product + " "
            //                        + item.Size + " "
            //                        + item.Received + " "
            //                        + "$" + item.Cost);

            //    }
            //    else
            //    {
            //        break;
            //    }
            //    Console.WriteLine("Create another item?");
            //}
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////

            Invoice item1 = new Invoice("Hummus", 3, 18.60);
            Invoice item2 = new Invoice("Foul", 2, 24.00);
            Invoice item3 = new Invoice("Baba Ganoush", 1, 26.50);
            Console.WriteLine(this.Product + " " + this.Received + " cases $" + this.Cost);


            Console.Write("Goodbye");
            Console.ReadKey();
		}
	}
}
