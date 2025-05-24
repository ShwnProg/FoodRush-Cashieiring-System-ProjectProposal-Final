using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodRush_CashieringSystem_Project_Final
{
    internal class Program
    {
        //---------------------------------------------------------------------------------------------------------------//

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\t\t\t\t\t\r\n                        ███████╗ ██████╗  ██████╗ ██████╗     ██████╗ ██╗   ██╗███████╗██╗  ██╗\r\n                        ██╔════╝██╔═══██╗██╔═══██╗██╔══██╗    ██╔══██╗██║   ██║██╔════╝██║  ██║\r\n                        █████╗  ██║   ██║██║   ██║██║  ██║    ██████╔╝██║   ██║███████╗███████║\r\n                        ██╔══╝  ██║   ██║██║   ██║██║  ██║    ██╔══██╗██║   ██║╚════██║██╔══██║\r\n                        ██║     ╚██████╔╝╚██████╔╝██████╔╝    ██║  ██║╚██████╔╝███████║██║  ██║\r\n                        ╚═╝      ╚═════╝  ╚═════╝ ╚═════╝     ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝\r\n                                                                                               \r\n");
            Console.ResetColor();

            // Call the login method
            PerformLogin();
        }

        // Let the user log in//
        //---------------------------------------------------------------------------------------------------------------//


        public static void PerformLogin()
        {
            bool isAccess = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t\t\t ╔═══════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t ║              Login            ║");
            Console.WriteLine("\t\t\t\t\t ╚═══════════════════════════════╝");
            Console.ResetColor();
            while (isAccess)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n\t\t\t\t\t >>Enter password : ");
                string password = Console.ReadLine();

                if (password == "admin123")
                {
                    isAccess = false;

                    // Show the main menu
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("\n\t\tLogging in");
                    for (int a = 0; a < 3; a++)
                    {
                        Thread.Sleep(500);
                        Console.Write(".");
                    }
                    Console.WriteLine("\n");
                    ShowMainMenu();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t\t\t\t\t Invalid password. Please try again.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        // Show the main menu options//
        //---------------------------------------------------------------------------------------------------------------//

        public static void ShowMainMenu()
        {
            string[,] orders = new string[1000, 10];

            int orderIndex = 0;
            int orderNumber = 1;
            bool inputAgain = true;

            // Load menu data
            InitializeFoodData(orders);

            while (inputAgain)
            {
                Console.Clear();
                //display main menu
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\t\t\t\t\t        \r\n                                                _                                     \r\n                                  /\\/\\    __ _ (_) _ __     /\\/\\    ___  _ __   _   _ \r\n                                 /    \\  / _` || || '_ \\   /    \\  / _ \\| '_ \\ | | | |\r\n                                / /\\/\\ \\| (_| || || | | | / /\\/\\ \\|  __/| | | || |_| |\r\n                                \\/    \\/ \\__,_||_||_| |_| \\/    \\/ \\___||_| |_| \\__,_|\r\n                                                                                      \r\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\t\t\t\t ═════════════════════════════════\n");
                Console.WriteLine("\t\t\t\t\t ╔═══════════════════════════════╗");
                Console.WriteLine("\t\t\t\t\t ║ 1. Cashiering Transaction     ║");
                Console.WriteLine("\t\t\t\t\t ║ 2. View Customer Order        ║");
                Console.WriteLine("\t\t\t\t\t ║ 3. View Sales                 ║");
                Console.WriteLine("\t\t\t\t\t ║ 4. EXIT                       ║");
                Console.WriteLine("\t\t\t\t\t ╚═══════════════════════════════╝");

                Console.ResetColor();
                // Prompt the user for an option
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n\t\t\t\t >>Select an option: ");
                string userOpt = Console.ReadLine();

                //validate user input
                while (userOpt != "1" && userOpt != "2" && userOpt != "3" && userOpt != "4")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n\t\t\t\tInvalid Input.Try Again.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\t\t\t\t >>Select an option: ");
                    userOpt = Console.ReadLine();
                    //Console.ResetColor();
                }


                switch (userOpt)
                {
                    case "1":
                        //Console.Clear();
                        Console.Write("\n\t\tLoading");
                        for (int b = 0; b < 3; b++)
                        {
                            Thread.Sleep(500);
                            Console.Write(".");
                        }
                        Console.WriteLine("\n");
                        // Start the cashiering process
                        ProcessCashieringTransaction(orders, ref orderIndex, ref orderNumber);
                        break;
                    case "2":
                        //Console.Clear();
                        Console.Write("\n\t\tLoading");
                        for (int c = 0; c < 3; c++)
                        {
                            Thread.Sleep(500);
                            Console.Write(".");
                        }
                        Console.WriteLine("\n");
                        // Start the view customer order
                        ViewCustomerOrder(orders, orderIndex);
                        break;
                    case "3":
                        Console.Write("\n\t\tLoading");
                        for (int d = 0; d < 3; d++)
                        {
                            Thread.Sleep(500);
                            Console.Write(".");
                        }
                        Console.WriteLine("\n");
                        // Start the view sales
                        ViewSales(orders, orderIndex);
                        break;
                    case "4":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n\t\t\t\t Thank you for using FoodRush Cashiering System!");
                        Console.WriteLine("\t\t\t\t --------------------------------------------------");
                        Console.WriteLine("\n\t\t\t\t Exiting the system...");
                        Console.ResetColor();

                        inputAgain = false;
                        break;
                }
            }
        }

        // Handle the cashiering transaction //
        //---------------------------------------------------------------------------------------------------------------//

        public static void ProcessCashieringTransaction(string[,] order, ref int orderIndex, ref int orderNumber)
        {

            bool anotherTransaction = true;
            bool validOrder;

            do
            {
                // Initialize variables
                double total = 0, grandTotal = 0;
                string food;
                string today = DateTime.Now.ToString("MM/dd/yyyy");
                int transactionOrderNumber = orderNumber, quantity = 0;
                bool orderAgain = true;
                validOrder = false;


                Console.Clear();

                // Display the Menu
                DisplayMenu(order);

                while (orderAgain)
                {
                    Console.Clear();
                    DisplayMenu(order);


                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\n >>Enter Item Code : ");
                    string itemNumber = Console.ReadLine();
                    Console.ResetColor();

                    // Get the food name
                    food = GetItemName(itemNumber, order);

                    // Get the price of the item
                    double price = GetItemPrice(itemNumber, order);

                    if (price != 0 && food != "")
                    {
                        quantity = GetValidQuantity();
                        Console.ResetColor();

                        total = price * quantity;
                        grandTotal += total;

                        // Show total price
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n ----------------------------------");
                        Console.WriteLine("\tAdded: {0} x {1} - PHP {2}", quantity, itemNumber, total);
                        Console.WriteLine(" ----------------------------------");
                        Console.ResetColor();

                        SaveOrderData(order, ref orderIndex, transactionOrderNumber, today, itemNumber, food, price, quantity, total);
                        validOrder = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n\t\tItem not found, please try again.");

                    }
                    // Ask if the user wants to order again
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\n\t\t >>Do you want to order again? (Y/N): ");
                    string continueOpt = Console.ReadLine();

                    // Validate user input
                    while (continueOpt != "Y" && continueOpt != "y" && continueOpt != "N" && continueOpt != "n")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n\t\t\t Invalid input. Please enter any key to try again.");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n\n\t\t >>Do you want to order again? (Y/N): ");
                        continueOpt = Console.ReadLine();
                        Console.ResetColor();
                    }
                    if (continueOpt == "Y" || continueOpt == "y")
                    {

                        orderAgain = true;
                    }
                    else
                    {
                        orderAgain = false;
                    }
                }

                // Check if a valid order was made
                if (validOrder == true && total > 0)
                {
                    Console.Clear();
                    orderNumber++;
                    // Show order summary
                    Console.ForegroundColor = ConsoleColor.White;
                    DisplayOrderSummary(order, ref orderIndex, transactionOrderNumber, today, grandTotal);
                    Console.ResetColor();
                    // Ask for payment
                    double cash = 0;

                    // Calculate the change
                    CalculateChange(cash, grandTotal);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n\t\t No valid order was made.");
                }
                // Ask if user wants another transaction
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n\n >>Start New Transaction (Y/N): ");
                string anotherTrans = Console.ReadLine();

                // Validate user input
                while (anotherTrans != "Y" && anotherTrans != "y" && anotherTrans != "N" && anotherTrans != "n")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\t\t\t Invalid input. Please enter Y or N: ");
                    anotherTrans = Console.ReadLine();
                }
                if (anotherTrans == "Y" || anotherTrans == "y")
                {
                    Console.Clear();
                    // Display the menu again
                    DisplayMenu(order);
                    anotherTransaction = true;
                }
                else
                {
                    anotherTransaction = false;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("\nReturning to the main menu");
                    for (int e = 0; e < 3; e++)
                    {
                        Thread.Sleep(500);
                        Console.Write(".");
                    }
                    Console.WriteLine("\n");
                }

            } while (anotherTransaction);
        }

        // Set up the menu data // - Menu Display
        //---------------------------------------------------------------------------------------------------------------//


        public static void InitializeFoodData(string[,] order)
        {
            // Combo Meals
            order[0, 0] = "C1"; order[0, 1] = "Ham Burger + Fries"; order[0, 2] = "159.00";
            order[1, 0] = "C2"; order[1, 1] = "Nuggets + Cheese Burger"; order[1, 2] = "199.00";
            order[2, 0] = "C3"; order[2, 1] = "Chicken Burger + Spaghetti"; order[2, 2] = "179.00";
            order[3, 0] = "C4"; order[3, 1] = "Pork Steak + Ham Burger"; order[3, 2] = "189.00";
            order[4, 0] = "C5"; order[4, 1] = "Fish Fillet + Mango Juice"; order[4, 2] = "169.00";

            // Drinks
            order[5, 0] = "D1"; order[5, 1] = "Iced Tea"; order[5, 2] = "39.00";
            order[6, 0] = "D2"; order[6, 1] = "Lemon Juice"; order[6, 2] = "49.00";
            order[7, 0] = "D3"; order[7, 1] = "Bottled Water"; order[7, 2] = "29.00";
            order[8, 0] = "D4"; order[8, 1] = "Mango Juice"; order[8, 2] = "59.00";
            order[9, 0] = "D5"; order[9, 1] = "Coffee"; order[9, 2] = "45.00";

            // Desserts
            order[10, 0] = "DE1"; order[10, 1] = "Ice Cream"; order[10, 2] = "59.00";
            order[11, 0] = "DE2"; order[11, 1] = "Brownies"; order[11, 2] = "69.00";
            order[12, 0] = "DE3"; order[12, 1] = "Cheesecake"; order[12, 2] = "89.00";
            order[13, 0] = "DE4"; order[13, 1] = "Fruit Salad"; order[13, 2] = "79.00";
            order[14, 0] = "DE5"; order[14, 1] = "Leche Flan"; order[14, 2] = "99.00";
        }

        // Show the menu items to the user // - Cashiering Transaction 
        //---------------------------------------------------------------------------------------------------------------//


        public static void DisplayMenu(string[,] order)
        {
            // Display the menu header
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n\n");
            Console.WriteLine("\t\t ╔════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t ║                            FoodRush Menu                                   ║");
            Console.WriteLine("\t\t ╚════════════════════════════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\t\t    Menu Code      Meal Name                                        Price  ");
            Console.WriteLine("\t\t   ╔════════════════════════════════════════════════════════════════════════════╗");

            // Display Combo Meals
            Console.WriteLine("\n\t\t   [Combo Meals]---------------------------------------------------------\n");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("\t\t    [{0}]       {1,-40} {2,8}", order[i, 0], order[i, 1], order[i, 2]);
            }

            // Display Drinks
            Console.WriteLine("\n\t\t   [Drinks]---------------------------------------------------------------\n");
            for (int i = 5; i < 10; i++)
            {
                Console.WriteLine("\t\t    [{0}]       {1,-40} {2,8}", order[i, 0], order[i, 1], order[i, 2]);
            }

            // Display Desserts
            Console.WriteLine("\n\t\t   [Desserts]--------------------------------------------------------------\n");
            for (int i = 10; i < 15; i++)
            {
                Console.WriteLine("\t\t    [{0}]       {1,-40} {2,8}", order[i, 0], order[i, 1], order[i, 2]);
            }

            Console.WriteLine("\t\t ╚════════════════════════════════════════════════════════════════════════════╝");
        }



        // Get the item name using the code // - Cashiering Transaction
        //---------------------------------------------------------------------------------------------------------------//

        public static string GetItemName(string orderChoice, string[,] order)
        {
            string food = "";
            orderChoice = orderChoice.ToUpper();
            for (int i = 0; i < order.GetLength(0); i++)
            {
                // Check if the item code matches the order choice
                if (order[i, 0] == orderChoice)
                {
                    food = order[i, 1]; // Get the food name
                    break;
                }
            }
            return food;
        }

        // Get the price using the code // - Cashiering Transaction
        //---------------------------------------------------------------------------------------------------------------//

        public static double GetItemPrice(string orderChoice, string[,] order)
        {
            // Initialize variables
            double price = 0;
            // Initialize a bool to check if the price was found
            bool priceFound = false;

            // Convert the order choice to uppercase for case-insensitive comparison
            orderChoice = orderChoice.ToUpper();

            // Loop through the order array to find the price
            for (int a = 0; a < 15; a++)
            {
                if (orderChoice == order[a, 0])
                {
                    // If the item code is found, get the price
                    price = Convert.ToDouble(order[a, 2]);
                    priceFound = true;
                    break;
                }
            }
            if (!priceFound)
            {
                // If the item code is not found, display an error message
                return 0;
            }
            return price;
        }

        // Get a valid quantity // - Cashiering Transaction
        //---------------------------------------------------------------------------------------------------------------//

        public static int GetValidQuantity()
        {
            bool validQuantity = true;
            int quantity = 0;
            while (validQuantity)
            {
                try
                {
                    // Prompt the user for the quantity
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n >>Enter quantity  : ");
                    quantity = int.Parse(Console.ReadLine());
                    if (quantity <= 0)
                    {
                        // If the quantity is invalid, prompt the user to enter a valid amount
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t\t Invalid quantity. Please enter a valid amount! ");
                        validQuantity = true;
                    }
                    else
                    {
                        // If the quantity is valid, exit the loop
                        validQuantity = false;
                    }
                }
                catch (FormatException)
                {
                    // Handle invalid input
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t\t Invalid input. Please enter a valid number! ");
                    validQuantity = true;
                }
            }
            return quantity;
        }

        // Method to save order data// - 2D Array
        //---------------------------------------------------------------------------------------------------------------//

        public static void SaveOrderData(string[,] order, ref int orderIndex, int transactionOrderNumber, string today, string itemNumber, string food, double price, int quantity, double total)
        {

            // Add bounds checking here
            if (orderIndex >= order.GetLength(0))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t Maximum orders reached! Cannot accept more orders.");
                Console.ResetColor();
                return;
            }
            // Save order data in the 2D array
            order[orderIndex, 3] = Convert.ToString(transactionOrderNumber);  // Order Number
            order[orderIndex, 4] = today;                                    // Date
            order[orderIndex, 5] = itemNumber.ToUpper();                    // Item Number
            order[orderIndex, 6] = food;                                   // Food Item
            order[orderIndex, 7] = Convert.ToString(price);               // Price
            order[orderIndex, 8] = Convert.ToString(quantity);           // Quantity
            order[orderIndex, 9] = Convert.ToString(total);             // Total * quantity = total


            orderIndex++;  // Increment the order index for the next order
        }

        // Show the full summary of the order// - Cashiering Transaction
        //---------------------------------------------------------------------------------------------------------------//

        public static void DisplayOrderSummary(string[,] orders, ref int orderIndex, int orderNumber, string today, double grandTotal)
        {
            // Display order summary header
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t ╔════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t ║                               ORDER SUMMARRY                               ║");
            Console.WriteLine("\t\t ╚════════════════════════════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t     Order Number : {0}", orderNumber);
            Console.WriteLine("\t\t     Date         : {0}", today);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t   -------------------------------------------------------------------------");
            Console.WriteLine("\t\t             Item                    Unit Price       Quantity      Price");
            Console.WriteLine("\t\t   -------------------------------------------------------------------------");
            for (int i = 0; i < orderIndex; i++)
            {
                if (orders[i, 3] == orderNumber.ToString())
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\t\t     {0,-26}         {1,-5}             {2,-5} {3,6} PHP", orders[i, 6],orders[i,7], orders[i, 8], orders[i, 9]);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\t\t   -------------------------------------------------------------------------");
            Console.WriteLine("\t\t     Total Amount   : {0,48} PHP", grandTotal);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t ╔════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t ║                   Review your order and proceed to payment.                ║");
            Console.WriteLine("\t\t ╚════════════════════════════════════════════════════════════════════════════╝");
        }


        // Ask for payment and show change // - Cashiering Transaction
        //---------------------------------------------------------------------------------------------------------------//

        public static bool CalculateChange(double cash, double grandTotal)
        {
            bool validCash = true;
            double change;

            do
            {
                try
                {
                    //prompt user for cash amount
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n >>Enter Cash : ");
                    cash = double.Parse(Console.ReadLine());

                    //validate cash amount
                    if (cash < grandTotal)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t\t\t Insufficient cash. Please enter a valid amount! ");
                    }
                    else
                    {
                        validCash = false;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t\t\t Invalid input. Please enter a valid amount: ");
                }

            } while (validCash);
            change = cash - grandTotal; //compute change
            if (cash == grandTotal)
            {
                //  display message if no change is required
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\t\t\t Exact amount received. No change required.");
                Console.WriteLine(" ╔════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine(" ║                       Thank you for your payment!                          ║");
                Console.WriteLine(" ╚════════════════════════════════════════════════════════════════════════════╝");

            }
            else
            {
                // display change
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n ------------------------");
                Console.WriteLine(" | Total Change : {0,5} |", change);
                Console.WriteLine(" ------------------------");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" ╔════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine(" ║                        Thank you for your payment!                         ║");
                Console.WriteLine(" ╚════════════════════════════════════════════════════════════════════════════╝");

            }
            return validCash;
        }

        //view customer order method//
        //---------------------------------------------------------------------------------------------------------------//

        public static void ViewCustomerOrder(string[,] orders, int orderIndex)
        {
            bool continueTransaction = false;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t ╔══════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t\t ║                              View Customer Order                             ║");
                Console.WriteLine("\t\t ╚══════════════════════════════════════════════════════════════════════════════╝");
            

                Console.ForegroundColor = ConsoleColor.Yellow;
                //validate order number
                Console.Write("\n\t\t >>Enter order number      : ");
                string orderNumber = Console.ReadLine();

                //validate date format
                Console.Write("\n\t\t >>Enter date [MM/DD/YYYY] : ");
                string dateOrder = Console.ReadLine();

                Console.ResetColor();
                //check if order number and date exist
                if (IsValidOrder(orderNumber, dateOrder, orders, orderIndex))
                {
                    //display order report header
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\n[Order Found]");
                    DisplayOrderDetails(orders, orderIndex, orderNumber, dateOrder);

                    //display order report details
                    double totalAmount = CalculateTotalAmount(orders, orderIndex, orderNumber, dateOrder);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\t\t | Grand Total  :      {0,63}  PHP |", totalAmount);
                    Console.WriteLine("\t\t --------------------------------------------------------------------------------------------");



                }
                else
                {
                    //display message if transaction not found
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n\t\t Transaction not found for the given order number and date.");
                }
                // Ask if user wants another transaction
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n\t >>Start New Transaction? (Y/N): ");
                string anotherTrans = Console.ReadLine();

                //validate user input
                while (anotherTrans != "Y" && anotherTrans != "y" && anotherTrans != "N" && anotherTrans != "n")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\n\t\tOops! Something went wrong with your input. Please try again.");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\n\t >>Start New Transaction? (Y/N): ");
                    anotherTrans = Console.ReadLine();
                }

                if (anotherTrans == "Y" || anotherTrans == "y")
                {
                    continueTransaction = false;
                }
                else
                {
                    continueTransaction = true;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("\nReturning to the main menu");
                    for (int e = 0; e < 3; e++)
                    {
                        Thread.Sleep(500);
                        Console.Write(".");
                    }
                    Console.WriteLine("\n");
                }

            } while (!continueTransaction);
        }

        //validate order// - View Customer Order
        //---------------------------------------------------------------------------------------------------------------//

        public static bool IsValidOrder(string orderNumber, string dateOrder, string[,] orders, int orderIndex)
        {
            //check if order number and date exist
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 3] == orderNumber && orders[j, 4] == dateOrder)
                {
                    return true;
                }
            }
            return false;
        }

        //display overall order details // - View Customer Order
        //---------------------------------------------------------------------------------------------------------------//
        public static void DisplayOrderDetails(string[,] orders, int orderIndex, string orderNumber, string dateOrder)
        {
            //display order report header
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t ╔═══════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t ║                                        ORDER DETAILS                                      ║");
            Console.WriteLine("\t\t ╚═══════════════════════════════════════════════════════════════════════════════════════════╝");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t --------------------------------------------------------------------------------------------");
            Console.WriteLine("\t\t |  Item Number    |            Food Item           |  Unit Price  |  Quantity  |   Total   |");
            Console.WriteLine("\t\t --------------------------------------------------------------------------------------------");

            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 3] == orderNumber && orders[j, 4] == dateOrder)
                {
                    //display order report details
                    Console.WriteLine("\t\t |      {0,-10} | {1,-30} | {2,6} PHP   |    {3,-7} | {4,5} PHP |",   orders[j, 5],
                                                                                                            orders[j, 6],
                                                                                                            orders[j, 7],
                                                                                                            orders[j, 8],
                                                                                                            orders[j, 9]);
                    Console.WriteLine("\t\t --------------------------------------------------------------------------------------------");



                }
            }

        }


        //calculate overall total// - View Customer Order
        //---------------------------------------------------------------------------------------------------------------//

        public static double CalculateTotalAmount(string[,] orders, int orderIndex, string orderNumber, string dateOrder)
        {
            double totalAmount = 0;
            //calculate grand total
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 3] == orderNumber && orders[j, 4] == dateOrder)
                {
                    totalAmount += Convert.ToDouble(orders[j, 9]);
                }
            }
            return totalAmount;
        }

        //view sales method//
        //---------------------------------------------------------------------------------------------------------------//

        public static void ViewSales(string[,] orders, int orderIndex)
        {
            bool continueTransaction = false;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t ╔══════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t\t ║                                    View Sales                                ║");
                Console.WriteLine("\t\t ╚══════════════════════════════════════════════════════════════════════════════╝");




                //prompt user for date
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n\t\t >>Enter date [MM/DD/YYY]: ");
                string date = Console.ReadLine();

                //validate date format
                if (IsTransactionFound(date, orders, orderIndex))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\n[Order Found]");
                    DisplayOverallTotalSales(orders, orderIndex, date);

                    //display order report details
                    double totalAmount = CalculateOverAllSales(orders, orderIndex, date);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\t\t | Total Sales   :      {0,50} PHP  |", totalAmount);
                    Console.WriteLine("\t\t --------------------------------------------------------------------------------");


                }
                else
                {
                    //display message if transaction not found
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n\t\t Transaction not found for the given date.");
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n\t\t >>Start New Transaction? (Y/N): ");
                string anotherTrans = Console.ReadLine();

                //validate user input
                while (anotherTrans != "Y" && anotherTrans != "y" && anotherTrans != "N" && anotherTrans != "n")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\n\t\t Oops! Something went wrong with your input. Please try again.");
                    Console.ReadKey();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\t\t >>Start New Transaction? (Y/N): ");
                    anotherTrans = Console.ReadLine();
                }
                if (anotherTrans == "Y" || anotherTrans == "y")
                {
                    continueTransaction = false;
                }
                else
                {
                    continueTransaction = true;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("\nReturning to the main menu");
                    for (int e = 0; e < 3; e++)
                    {
                        Thread.Sleep(500);
                        Console.Write(".");
                    }
                    Console.WriteLine("\n");
                }
            } while (!continueTransaction);


        }

         //validate order// - View Sales
        //---------------------------------------------------------------------------------------------------------------//

        public static bool IsTransactionFound(string dateOrder, string[,] orders, int orderIndex)
        {
            //check if date exist
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 4] == dateOrder)
                {
                    return true;
                }
            }
            return false;
        }

         //display overall total sales// - View Sales
        //---------------------------------------------------------------------------------------------------------------//

        public static void DisplayOverallTotalSales(string[,] orders, int orderIndex, string dateOrder)
        {
            //display sales report header
            // Header with Smooth Box and Color
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t ╔══════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t ║                                    SALES REPORT                              ║");
            Console.WriteLine("\t\t ╚══════════════════════════════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t --------------------------------------------------------------------------------");
            Console.WriteLine("\t\t |         Food Item          |    Unit Price     |   Quantity   |     Total    |");
            Console.WriteLine("\t\t --------------------------------------------------------------------------------");


            //for (int j = 0; j < orderIndex; j++)
            //{
            //    if (orders[j, 4] == dateOrder)
            //    {
            //        //display sales report details
            //        Console.WriteLine("\t\t| {1,-45} |     {2,-5}PHP      |        {3,-7}     |     {4,-5}PHP |", orders[j, 5],
            //                                                                                                            orders[j, 6],
            //                                                                                                            orders[j, 7],
            //                                                                                                            orders[j, 8],
            //                                                                                                            orders[j, 9]);
            //        Console.WriteLine("\t\t---------------------------------------------------------------------------------------------------------");

            //    }
            //}

            int c1 = 0;
            double cT1 = 0;
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 4] == dateOrder && orders[j, 5] == "C1")
                {
                    c1 += Convert.ToInt32(orders[j, 8]);
                    cT1 += Convert.ToDouble(orders[j, 9]);
                }

            }

            if (c1 > 0)
            {
                Console.WriteLine("\t\t | {0,-26} |    PHP {1,-6}     |      {2,-5}   |    PHP {3,-5} |",orders[0,1],orders[0,2], c1, cT1);
                Console.WriteLine("\t\t --------------------------------------------------------------------------------");


            }
            int c2 = 0;
            double cT2 = 0;
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 4] == dateOrder && orders[j, 5] == "C2")
                {
                    c2 += Convert.ToInt32(orders[j, 8]);
                    cT2 += Convert.ToDouble(orders[j, 9]);
                }

            }

            if (c2 > 0)
            {
                Console.WriteLine("\t\t | {0,-26} |    PHP {1,-6}     |      {2,-5}   |    PHP {3,-5} |",orders[1,1], orders[1, 2], c2, cT2);
                Console.WriteLine("\t\t --------------------------------------------------------------------------------");

            }
            int c3 = 0;
            double cT3 = 0;
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 4] == dateOrder && orders[j, 5] == "C3")
                {
                    c3 += Convert.ToInt32(orders[j, 8]);
                    cT3 += Convert.ToDouble(orders[j, 9]);
                }

            }

            if (c3 > 0)
            {
                Console.WriteLine("\t\t | {0,-26} |    PHP {1,-6}     |      {2,-5}   |    PHP {3,-5} |", orders[2, 1], orders[2, 2], c3, cT3);
                Console.WriteLine("\t\t --------------------------------------------------------------------------------");

            }

            int c4 = 0;
            double cT4 = 0;
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 4] == dateOrder && orders[j, 5] == "C4")
                {
                    c4 += Convert.ToInt32(orders[j, 8]);
                    cT4 += Convert.ToDouble(orders[j, 9]);
                }

            }

            if (c4 > 0)
            {
                Console.WriteLine("\t\t | {0,-26} |    PHP {1,-6}     |      {2,-5}   |    PHP {3,-5} |", orders[3, 1], orders[3, 2], c4, cT4);
                Console.WriteLine("\t\t --------------------------------------------------------------------------------");

            }

            int c5 = 0;
            double cT5 = 0;
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 4] == dateOrder && orders[j, 5] == "C5")
                {
                    c5 += Convert.ToInt32(orders[j, 8]);
                    cT5 += Convert.ToDouble(orders[j, 9]);
                }

            }

            if (c5 > 0)
            {
                Console.WriteLine("\t\t | {0,-26} |    PHP {1,-6}     |      {2,-5}   |    PHP {3,-5} |", orders[4, 1], orders[4, 2], c5, cT5);
                Console.WriteLine("\t\t --------------------------------------------------------------------------------");

            }

            int d1 = 0;
            double dT1 = 0;
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 4] == dateOrder && orders[j, 5] == "D1")
                {
                    d1 += Convert.ToInt32(orders[j, 8]);
                    dT1 += Convert.ToDouble(orders[j, 9]);
                }

            }

            if (d1 > 0)
            {
                Console.WriteLine("\t\t | {0,-26} |    PHP {1,-6}     |      {2,-5}   |    PHP {3,-5} |", orders[5, 1], orders[5, 2], d1, dT1);
                Console.WriteLine("\t\t --------------------------------------------------------------------------------");

            }

            int d2 = 0;
            double dT2 = 0;
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 4] == dateOrder && orders[j, 5] == "D2")
                {
                    d2 += Convert.ToInt32(orders[j, 8]);
                    dT2 += Convert.ToDouble(orders[j, 9]);
                }

            }

            if (d2 > 0)
            {
                Console.WriteLine("\t\t | {0,-26} |    PHP {1,-6}     |      {2,-5}   |    PHP {3,-5} |", orders[6, 1], orders[6, 2], d2, dT2);
                Console.WriteLine("\t\t --------------------------------------------------------------------------------");

            }

            int d3 = 0;
            double dT3 = 0;
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 4] == dateOrder && orders[j, 5] == "D3")
                {
                    d3 += Convert.ToInt32(orders[j, 8]);
                    dT3 += Convert.ToDouble(orders[j, 9]);
                }

            }

            if (d3 > 0)
            {
                Console.WriteLine("\t\t | {0,-26} |    PHP {1,-6}     |      {2,-5}   |    PHP {3,-5} |", orders[7, 1], orders[7, 2], d3, dT3);
                Console.WriteLine("\t\t --------------------------------------------------------------------------------");

            }

            int d4 = 0;
            double dT4 = 0;
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 4] == dateOrder && orders[j, 5] == "D4")
                {
                    d4 += Convert.ToInt32(orders[j, 8]);
                    dT4 += Convert.ToDouble(orders[j, 9]);
                }

            }

            if (d4 > 0)
            {
                Console.WriteLine("\t\t | {0,-26} |    PHP {1,-6}     |      {2,-5}   |    PHP {3,-5} |", orders[8, 1], orders[8, 2], d4, dT4);
                Console.WriteLine("\t\t --------------------------------------------------------------------------------");

            }

            int d5 = 0;
            double dT5 = 0;
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 4] == dateOrder && orders[j, 5] == "D5")
                {
                    d5 += Convert.ToInt32(orders[j, 8]);
                    dT5 += Convert.ToDouble(orders[j, 9]);
                }

            }

            if (d5 > 0)
            {
                Console.WriteLine("\t\t | {0,-26} |    PHP {1,-6}     |      {2,-5}   |    PHP {3,-5} |", orders[9, 1], orders[9, 2], d5, dT5);
                Console.WriteLine("\t\t --------------------------------------------------------------------------------");

            }

            int  dE1 = 0;
            double dET1 = 0;
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 4] == dateOrder && orders[j, 5] == "DE1")
                {
                    dE1 += Convert.ToInt32(orders[j, 8]);
                    dET1 += Convert.ToDouble(orders[j, 9]);
                }

            }

            if (dE1 > 0)
            {
                Console.WriteLine("\t\t | {0,-26} |    PHP {1,-6}     |      {2,-5}   |    PHP {3,-5} |", orders[10, 1], orders[10, 2], dE1, dET1);
                Console.WriteLine("\t\t --------------------------------------------------------------------------------");

            }

            int dE2 = 0;
            double dET2 = 0;
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 4] == dateOrder && orders[j, 5] == "DE2")
                {
                    dE2 += Convert.ToInt32(orders[j, 8]);
                    dET2 += Convert.ToDouble(orders[j, 9]);
                }

            }

            if (dE2 > 0)
            {
                Console.WriteLine("\t\t | {0,-26} |    PHP {1,-6}     |      {2,-5}   |    PHP {3,-5} |", orders[11, 1], orders[11, 2], dE2, dET2);
                Console.WriteLine("\t\t --------------------------------------------------------------------------------");

            }

            int dE3 = 0;
            double dET3 = 0;
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 4] == dateOrder && orders[j, 5] == "DE3")
                {
                    dE3 += Convert.ToInt32(orders[j, 8]);
                    dET3 += Convert.ToDouble(orders[j, 9]);
                }

            }

            if (dE3 > 0)
            {
                Console.WriteLine("\t\t | {0,-26} |    PHP {1,-6}     |      {2,-5}   |    PHP {3,-5} |", orders[12, 1], orders[12, 2], dE2, dET2);
                Console.WriteLine("\t\t --------------------------------------------------------------------------------");

            }

            int dE4 = 0;
            double dET4 = 0;
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 4] == dateOrder && orders[j, 5] == "DE4")
                {
                    dE4 += Convert.ToInt32(orders[j, 8]);
                    dET4 += Convert.ToDouble(orders[j, 9]);
                }

            }

            if (dE4 > 0)
            {
                Console.WriteLine("\t\t | {0,-26} |    PHP {1,-6}     |      {2,-5}   |    PHP {3,-5} |", orders[13, 1], orders[13, 2], dE4, dET4);
                Console.WriteLine("\t\t --------------------------------------------------------------------------------");

            }

            int dE5 = 0;
            double dET5 = 0;
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 4] == dateOrder && orders[j, 5] == "DE5")
                {
                    dE5 += Convert.ToInt32(orders[j, 8]);
                    dET5 += Convert.ToDouble(orders[j, 9]);
                }               

            }

            if (dE5 > 0)
            {
                Console.WriteLine("\t\t | {0,-26} |    PHP {1,-6}     |      {2,-5}   |    PHP {3,-5} |", orders[14, 1], orders[14, 2], dE5, dET5);
                Console.WriteLine("\t\t --------------------------------------------------------------------------------");

            }
        }

        //calculate overall total sales// - View Sales
        //---------------------------------------------------------------------------------------------------------------//

        public static double CalculateOverAllSales(string[,] orders, int orderIndex, string dateOrder)
        {
            double totalAmount = 0;
            //calculate total sales
            for (int j = 0; j < orderIndex; j++)
            {
                if (orders[j, 4] == dateOrder)
                {
                    totalAmount += Convert.ToDouble(orders[j, 9]);
                }
            }
            return totalAmount;
        }

    }

}


