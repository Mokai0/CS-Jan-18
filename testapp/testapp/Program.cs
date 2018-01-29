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

			var Menu = "1] See current Stock \n2] Create a new Invoice" + Environment.NewLine + "3] Check invoice History";
			//In the above line of code "\n" and "Environment.NewLine" serve the same function however while \n is much shorter Environment.NewLine is supposedly more context correct/savvy. 

			Console.WriteLine(Menu);

            string selection = Console.ReadLine();
            if ( selection == "1")
            {
                Console.WriteLine("You've selected to see your current Stock.");
            }
            else if( selection == "2")
            {
                Console.WriteLine("You've selected to create a new Invoice.");
            }
            else if( selection == "3")
            {
                Console.WriteLine("You've selected to see your invoice History.");
            }
            else
            {
                Console.WriteLine("You didn't pick a valid option");
            }


            Console.ReadKey();
		}
	}
}