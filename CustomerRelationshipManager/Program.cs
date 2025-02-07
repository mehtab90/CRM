using System;
using CustomerRelationshipManager.Services;
using CustomerRelationshipManager;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

class Program
{
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
           .AddSingleton<ICustomerService, CustomerService>()
           .BuildServiceProvider();

        var customerService = serviceProvider.GetService<ICustomerService>();       
        string filePath = ConfigurationManager.AppSettings["CSVFilePath"];
        customerService.LoadData(filePath);
        
            Console.WriteLine("Customer and Vehicle Reports:");
            Console.WriteLine("1. All customers and their vehicles");
            Console.WriteLine("2. Customers between age 20 and 30");
            Console.WriteLine("3. Vehicles registered before 1st January 2010");
            Console.WriteLine("4. Vehicles with engine size over 1100");
            Console.Write("Select a report (1-4): ");
            Console.WriteLine("5. Exit Application.");
            
            string choice = Console.ReadLine();
        Console.WriteLine($"***********************************************************************************************");

        switch (choice)
            {
                case "1":
                    customerService.PrintAllCustomersAndVehicles();
                    break;
                case "2":
                    customerService.PrintCustomersBetweenAges(20, 30);
                    break;
                case "3":
                    customerService.PrintVehiclesRegisteredBefore(new DateTime(2010, 1, 1));
                    break;
                case "4":
                    customerService.PrintVehiclesWithEngineSizeGreaterThan(1100);
                    break;            
                case "5":
                Environment.Exit(0);
                break;
            default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        Console.WriteLine($"***********************************************************************************************");


        Console.WriteLine("Do you want to view more reports?(Y/N).");
        choice = Console.ReadLine();
        if (choice == "Y" || choice == "y")
        {
            Main();
        }
        else
        {
            
            Environment.Exit(0);    

        }




    }
}