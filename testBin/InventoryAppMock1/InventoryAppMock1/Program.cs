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
        // This collection of property names needs to match the list of the properties that appear in the products list page.
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
                    default:
                        if (AttemptDisplayProduct(command, productIds))
                        {
                            command = CommandListProducts;
                            continue;
                        }
                        else
                        {
                            ConsoleHelper.OutputLine("Sorry, wrong command.");
                        }
                        break;
                }

                //List of the available commands:
                ConsoleHelper.OutputBlankLine();
                ConsoleHelper.Output("Commands: ");
                int productCount = Repository.GetProductCount();
                if (productCount > 0)
                {
                    ConsoleHelper.Output("Enter a Number 1-{0}, ", productCount);
                }
                ConsoleHelper.OutputLine("A - Add, Q - Quit", false);

                command = ConsoleHelper.ReadInput("Enter a Command: ", true);
            }
        }

        //<summary> Attempts parse the provided command as a line number, returns product.ItemTag for the referenced product if successful.
        //<returns> Returns 'true' if the product selection was successful and 'false' otherwise.
        ///<param name="command"> The line number command selected.
        ///<paramref name="productIds"/> The selected product's Id.
        private static bool AttemptDisplayProduct(string command, IList<int> productIds)
        {
            var successful = false;
            int? productId = null;

            //Only attempt to parse the command to a line number if we have a collection of product Ids available.
            if (productIds != null)
            {
                //Attempt to parse the command to a line number:
                int lineNumber = 0;
                int.TryParse(command, out lineNumber);

                //If the number is within range then get that product Id.
                if (lineNumber > 0 && lineNumber <= productIds.Count)
                {
                    productId = productIds[lineNumber - 1];
                    successful = true;
                }
            }

            //if we have a product Id then display the product.ItemTag.
            if (productId != null)
            {
                DisplayProduct(productId.Value);
            }
            return successful;
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
            //This last one will be #gravy.

            //Add the product to the database:
            Repository.AddProduct(product);
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
                    else //Add a stipulation to create another brand #gravy
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
                        categoryId = categories[lineNumber - 1].Id;
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
            //ConsoleHelper.Output();
            string pName = ConsoleHelper.ReadInput("What is the product's name: ");
            while (string.IsNullOrWhiteSpace(pName))
            {
                pName = ConsoleHelper.ReadInput("There needs to be a name for the product: ");
            }
            return pName;
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
                product.ItemTag);
                //product.ItemInfo);
            }

            return productIds;
        }

        //<summary> Displays the product's information for the provided productId.
        //<returns> Null.
        ///<param name="productId"> The selected product's Id.
        private static void DisplayProduct(int productId)
        {
            string command = CommandListProduct;

            //If the current command isn't "Cancel" then evaluate:
            while (command != CommandCancel)
            {
                switch (command)
                {
                    case CommandListProduct:
                        ListProduct(productId);
                        break;
                    case CommandUpdateProduct:
                        UpdateProduct(productId);
                        command = CommandListProduct;
                        continue;
                    case CommandDeleteProduct:
                        if (DeleteProduct(productId))
                        {
                            command = CommandCancel;
                        }
                        else
                        {
                            command = CommandListProduct;
                        }
                        continue;
                    default:
                        ConsoleHelper.OutputLine("Please try a valid response.");
                        break;
                }

                //List the available commands:
                ConsoleHelper.OutputBlankLine();
                ConsoleHelper.Output("Commands: ");
                ConsoleHelper.OutputLine("U - Update, D - Delete, C - Cancel", false);

                //Get the next command from the user.
                command = ConsoleHelper.ReadInput("Enter a command: ", true);
            }
        }

        //<summary> First checks that the user wants to delete the selected product, then confirms it before deleting.
        //<returns> "true" if the product was deleted, "false" otherwise.
        ///<param name="productId"> The product's Id.
        private static bool DeleteProduct(int productId)
        {
            var successful = false;
            //The confirmation prompt:
            string input = ConsoleHelper.ReadInput("Are you sure you want to delete this product? (Y/N)", true);

            //If "y":
            if (input == "y")
            {
                Repository.DeleteProduct(productId);
                successful = true;
            }
            return successful;
        }

        //<summary> Lists the information for the product selected by Id.
        //<returns> Null.
        ///<param name="productId"> The selected product's Id.
        private static void ListProduct(int productId)
        {
            Product product = Repository.GetProduct(productId);

            ConsoleHelper.ClearOutput();
            ConsoleHelper.OutputLine(product.Brand.Name + " " + product.ProductName + " information:");
            ConsoleHelper.OutputBlankLine();

            //Category
            ConsoleHelper.OutputLine("This Item is found in the {0} isle", product.Category.Ref);
            ConsoleHelper.OutputBlankLine();

            //Quantity
            ConsoleHelper.OutputLine("There are {0} cases of this item currently in stock", product.Quantity);
            ConsoleHelper.OutputBlankLine();

            //Expiration - remember this is #gravy
            //if (!string.IsNullOrWhiteSpace(product.ExpirationDate))
            //{
            //    ConsoleHelper.OutputLine("Expires on: {0}", product.ExpirationDate.ToShortDateString());
            //}
        }

        //<summary> Lists the editable properties for the selected product.
        //<returns> Null.
        ///<param name="productId"> The selected product's Id.
        private static void UpdateProduct(int productId)
        {
            Product product = Repository.GetProduct(productId);
            string command = CommandListProductProperties;

            //If the current command isn't "Cancel" then keep going:
            while (command != CommandCancel)
            {
                switch (command)
                {
                    case CommandListProductProperties:
                        ListProductProperties(product);
                        break;
                    case CommandSave:
                        Repository.UpdateProduct(product);
                        command = CommandCancel;
                        continue;
                    default:
                        if (AttemptUpdateProductProperty(command, product))
                        {
                            command = CommandListProductProperties;
                            continue;
                        }
                        else
                        {
                            ConsoleHelper.OutputLine("Try again.");
                        }
                        break;
                }

                //List the available commands:
                ConsoleHelper.OutputBlankLine();
                ConsoleHelper.Output("Commands: ");
                if (EditableProperties.Count > 0)
                {
                    ConsoleHelper.Output("Enter a Number 1-{0}, ", EditableProperties.Count);
                }
                ConsoleHelper.OutputLine("S - Save, C - Cancel", false);

                //Get the next command from the user:
                command = ConsoleHelper.ReadInput("Enter a Command: ", true);
            }
            ConsoleHelper.ClearOutput();
        }

        //<summary> Attempts to parse the provided command, calls the appropriate user input method if successful.
        //<returns> "true" if the product property was updated successfully, otherwise "false".
        ///<param name="command"> The selected command.
        ///<paramref name="product"> The product to update.
        private static bool AttemptUpdateProductProperty(string command, Product product)
        {
            var successful = false;
            //Attempt to parse the command to a line number, the implementation of this method already handles a failure in parsing.
            int lineNumber = 0;
            int.TryParse(command, out lineNumber);

            //If line number is within range then get the product Id:
            if (lineNumber > 0 && lineNumber <= EditableProperties.Count)
            {
                string propertyName = EditableProperties[lineNumber - 1];
                switch (propertyName)
                {
                    case "BrandId":
                        product.Brand.Id = GetBrandId();
                        product.Brand = Repository.GetBrand(product.Brand.Id);
                        break;
                    case "CategoryId":
                        product.Category.Id = GetCategoryId();
                        product.Category = Repository.GetCategory(product.Category.Id);
                        break;
                    case "ProductName":
                        product.ProductName = GetProductName();
                        break;
                    case "Quantity":
                        product.Quantity = GetQuantity();
                        break;
                    //#gravy
                    //case "ExpirationDate":
                    //    product.ExpirationDate = GetExpirationDate();
                    //    break;
                    default:
                        break;
                }
                successful = true;
            }
            return successful;
        }

        //<summary> Lists the editable product properties.
        //<returns> Null.
        ///<param name="product"> The prodcut whose properties to list.
        private static void ListProductProperties(Product product)
        {
            ConsoleHelper.ClearOutput();
            ConsoleHelper.OutputLine("Update: " + product.ItemTag);

            //MUST match the collection of editable properties declared before Main() at top of this file:
            //ConsoleHelper.OutputBlankLine();
            //ConsoleHelper.OutputLine("1) Brand: {0}", product.Brand.Name);
            //ConsoleHelper.OutputBlankLine();
            //ConsoleHelper.OutputLine("2) Category: {0}", product.Category.Info);
            //ConsoleHelper.OutputBlankLine();
            //ConsoleHelper.OutputLine("3) Product Name: {0}", product.ProductName);
            ConsoleHelper.OutputBlankLine();
            ConsoleHelper.OutputLine("4) Quantity: {0}", product.Quantity);
            //Remember - #gravy
            //ConsoleHelper.OutputBlankLine();
            //ConsoleHelper.OutputLine("5) Expiration Date: {0}", product.ExpirationDate);

        }
    }
}