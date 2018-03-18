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
                    case CommandAddProduct:
                        AddProduct();
                        command = CommandListProducts;
                        continue;
                    //default:
                    //    if (AttemptDisplayProduct(command, productIds))
                    //    {
                    //        command = CommandListProducts;
                    //        continue;
                    //    }
                    //    else
                    //    {
                    //        ConsoleHelper.OutputLine("Sorry, wrong command.");
                    //    }
                        break;
                }
            }
        }

        //<summary> Promts for product values to add then adds product to database.
        //<returns> Null.
        private static void AddProduct()
        {
            ConsoleHelper.ClearOutput();
            ConsoleHelper.OutputLine("Add a product");

            //Get the product's values from the user:
            var product = new Product();
            product.BrandId = GetBrandId();
            product.CategoryId = GetCategoryId();
            product.ProductName = GetProductName();
            product.Quantity = GetQuantity();
            //product.ExpirationDate = GetExpirationDate();
            //This last one will be gravy.
        }

        //<summary> Gets the needed Brand Id based on user input.
        //<returns> A specific Brand's Id as an integar.
        private static int GetBrandId()
        {
            int? brandId = null;
            IList<Brand> brands = Repository.GetBrands();

            //While the brandId is null prompt the user to pick a Brand form a list:
            while (brandId == null)
            {
                ConsoleHelper.OutputBlankLine();

                foreach (Brand b in brands)
                {
                    ConsoleHelper.OutputLine("{0}) {1}", brands.IndexOf(b) + 1, b.Name);
                }

                //Get the line number for the selected Brand
                string lineNumberInput = ConsoleHelper.ReadInput("What Brand is this product?");
                int lineNumber = 0;
                if (int.TryParse(lineNumberInput, out lineNumber))
                {
                    if (lineNumber > 0 && lineNumber <= brands.Count)
                    {
                        brandId = brands[lineNumber - 1].Id;
                    }
                    else
                    {
                        ConsoleHelper.OutputLine("\"" + lineNumber + "\" is not a valid choice. Please try again");
                    }
                }
            }

            return brandId.Value;
        }

        //<summary> Gets the Category that the user selected.
        //<returns> An Id for the Category that the user selected.
        private static int GetCategoryId()
        {
            int? categoryId = null;
            IList<Category> categories = Repository.GetCategories();

            while (categoryId == null)
            {
                ConsoleHelper.OutputBlankLine();
                foreach (Category c in categories)
                {
                    ConsoleHelper.OutputLine("{0}) {1}", categories.IndexOf(c) + 1, c.Info);
                }

                string lineInput = ConsoleHelper.ReadInput("Where does this product go?");
                int lineNumber = 0;
                if (int.TryParse(lineInput, out lineNumber))
                {
                    if (lineNumber > 0 && lineNumber < categories.Count)
                    {
                        categoryId = categories[lineNumber--].Id;
                    }
                    else
                    {
                        ConsoleHelper.OutputLine("\"" + lineNumber + "\" is an invalid selection. Please try again");
                    }
                }
            }
            return categoryId.Value;
        }

        //<summary> Takes the users input and creates a name for the new product.
        //<returns> The user's input as a string and passes it into the product.ProductName.
        private static string GetProductName()
        {
            return ConsoleHelper.ReadInput("What is the product's name: ");
        }

        //<summary> Takes the user's input as the quantity of the product currently in stock.
        //<returns> The user's input as a decimal for the product.Quantity.
        private static decimal GetQuantity()
        {
            decimal? quantity = null;
            while (quantity == null)
            {
                string qInput = ConsoleHelper.ReadInput("How many cases of this product do you have?: ");
                decimal qCount;
                if (decimal.TryParse(qInput, out qCount))
                {
                    quantity = qCount;
                }
                else
                {
                    ConsoleHelper.OutputLine("Sorry, I need a valid number");
                }
            }
            return quantity.Value;
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
