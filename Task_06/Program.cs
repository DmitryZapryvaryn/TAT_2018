using System;
using System.Text;
using System.Text.RegularExpressions;
using Task_06.Controller;
using Task_06.Controller.Command.impl;
using Task_06.Entity;

namespace Task_06
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();
            CommandProvider comProvider = new CommandProvider();
            while (true)
            {
                try
                {
                    Console.WriteLine("Product type: ");
                    string type = Console.ReadLine();
                    Console.WriteLine("Product name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Product quantity: ");
                    int quantity = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Product price: ");
                    double price = Double.Parse(Console.ReadLine());

                    warehouse.AddProduct(new ProductBuilder().SetType(type)
                                                             .SetName(name)
                                                             .SetQuantity(quantity)
                                                             .SetPrice(price)
                                                             .Build());
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
               

                Console.WriteLine("Add another product?(y/n)");
                string answer = Console.ReadLine();
                if (answer == "n")
                {
                    break;
                }
            }

            Console.WriteLine(warehouse.ToString());

            bool exit = false;
            while(!exit)
            {
                try
                {
                    Console.WriteLine("Input command: ");
                    string command = Console.ReadLine();
                    switch (command)
                    {
                        case "count types":
                            comProvider.SetCommand(new CountTypeCommand(warehouse));
                            comProvider.Execute();
                            break;
                        case "count all":
                            comProvider.SetCommand(new CountAllCommand(warehouse));
                            comProvider.Execute();
                            break;
                        case "average price":
                            comProvider.SetCommand(new AveragePriceCommand(warehouse));
                            comProvider.Execute();
                            break;
                        case string priceForType when new Regex(@"average price (\w+)").IsMatch(command):
                            Regex pattern = new Regex(@"(?<=\bprice\s)(\w+)");
                            Match match = pattern.Match(command);
                            string type = match.Groups[1].Value;
                            Console.WriteLine(type);
                            break;
                        case "exit":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("No such command!");
                            break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
    }
}
