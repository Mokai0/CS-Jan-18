using InventoryShared;
using InventoryShared.Models;
using InventoryShared.Data;
using InventoryAppMock1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace InventoryAppMock1
{
    class Program
    {
        // These are the various commands that can be performed 
        // in the app. Each command must have a unique string value.
        const string CommandListProducts = "l";
        const string CommandListProduct = "i";
        const string CommandListProductProperties = "p";
        const string CommandAddProduct = "a";
        const string CommandUpdateProduct = "u";
        const string CommandDeleteProduct = "d";
        const string CommandSave = "s";
        const string CommandCancel = "c";
        const string CommandQuit = "q";

        // A collection of the product's editable properties.
        // This collection of property names needs to match the list of the properties that appear in the product.ItemInfo property.
        readonly static List<string> EditableProperties = new List<string>()
        {
            "BrandId",
            "CategoryId",
            "ProductName",
            "Quantity",
            "ExpirationDate"
        };

        //This is what runs when the app is launched:
        static void Main(string[] args) 
        {
            string command = CommandListProducts;
            IList<int> productIds = null;

            //If the current command doesn't equal the "Quit" command then evaluate and process the command.
            while (command != CommandQuit)
            {
                switch (command)
                {
                    case CommandListProducts:
                        productIds = ListProducts();
                        break;
                }
            }
        }

        //<summary> Retrieves the products from the database and lists them
        //<returns> A collection of the product Id's in the same order as the products were listed to facilitate selecting a product by line number
        private static IList<int> ListProducts()
        {
            var productIds = new List<int>();
            IList<Product> products = Repository.GetProducts();

            ConsoleHelper.ClearOutput();
            ConsoleHelper.OutputLine("Inventory");

            ConsoleHelper.OutputBlankLine();

            foreach (Product product in products)
            {
                productIds.Add(product.Id);

                ConsoleHelper.OutputLine("{0}) {1}",
                    products.IndexOf(product) + 1,
                    product.ItemInfo);
            }

            return productIds;
        }
    }
}
