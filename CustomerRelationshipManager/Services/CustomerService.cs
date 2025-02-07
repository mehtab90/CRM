using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CustomerRelationshipManager.Model;


namespace CustomerRelationshipManager.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers = new List<Customer>();

         void ICustomerService.LoadData(string filePath)
        {
           // List<Customer> customers = new List<Customer>();
            
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");                
            }

            var lines = File.ReadAllLines(filePath).Skip(1); 
            foreach (var line in lines)
            {
                var parts = line.Split(',');

                if (parts.Length < 10) continue;

                int customerId = int.Parse(parts[0]);
                string forename = parts[1];
                string surname = parts[2];
                DateTime dob = DateTime.Parse(parts[3]);

                int vehicleId = int.Parse(parts[4]);
                string regNumber = parts[5];
                string manufacturer = parts[6];
                string model = parts[7];
                int engineSize = int.Parse(parts[8]);
                DateTime regDate = DateTime.Parse(parts[9]);
                string interiorColor = parts[10];

                Customer customer = _customers.FirstOrDefault(c => c.CustomerId == customerId);
                if (customer == null)
                {
                    customer = new Customer(customerId, forename, surname, dob);
                    _customers.Add(customer);
                }

                customer.Vehicles.Add(new Vehicle(vehicleId, regNumber, manufacturer, model, engineSize, regDate, interiorColor));
            }

           
        }

        public void PrintAllCustomersAndVehicles()
        {
            foreach (var customer in _customers)
            {
                Console.WriteLine($"{customer.Forename} {customer.Surname} (DOB: {customer.DateOfBirth:yyyy-MM-dd})");
                Console.WriteLine("Vehicles:");
                foreach (var vehicle in customer.Vehicles)
                {
                    Console.WriteLine($"  - {vehicle.Manufacturer} {vehicle.Model} ({vehicle.RegistrationNumber})");
                }
            }
        }

        public void PrintCustomersBetweenAges(int minAge, int maxAge)
        {
            var today = DateTime.Today;
            var customers = _customers.Where(c =>
            {
                var age = today.Year - c.DateOfBirth.Year;
                if (c.DateOfBirth.Date > today.AddYears(-age)) age--;
                return age >= minAge && age <= maxAge;
            });
            if(!customers.Any())
            {
                Console.WriteLine($"No Customer in this age range.");
            }
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Forename} {customer.Surname} - DOB: {customer.DateOfBirth:yyyy-MM-dd}");
            }
        }

        public void PrintVehiclesRegisteredBefore(DateTime date)
        {
            var vehicles = _customers.SelectMany(c => c.Vehicles)
                .Where(v => v.RegistrationDate < date);
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle.Manufacturer} {vehicle.Model} - Registered: {vehicle.RegistrationDate:yyyy-MM-dd}");
            }
        }

        public void PrintVehiclesWithEngineSizeGreaterThan(int size)
        {
            var vehicles = _customers.SelectMany(c => c.Vehicles)
                .Where(v => v.EngineSize > size);
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle.Manufacturer} {vehicle.Model} - Engine Size: {vehicle.EngineSize}cc");
            }
        }

        
    }
}
