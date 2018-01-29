using System;
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
			var Menu = "See current Stock \nCreate a new Invoice" + Environment.NewLine + "Check invoice History";
			//In the above line of code "\n" and "Environment.NewLine" serve the same function however while \n is much shorter Environment.NewLine is supposedly more context correct/savvy. 

			Console.WriteLine(Menu);
			Console.ReadKey();
		}
	}
}
