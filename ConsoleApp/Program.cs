using Default;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceRoot = "https://localhost:44357/odata";
            var context = new Container(new Uri(serviceRoot));

            // Example #1
            #region Example #1
            //var vehicles = context.Vehicles.ExecuteAsync().Result;
            //foreach (var vehicle in vehicles)
            //{
            //    Console.WriteLine($"{vehicle.Id} - {vehicle.Model}");
            //}
            #endregion

            // Example #2
            #region Example #2
            var expandedVehicles = context.Vehicles.Expand(e => e.Manufacturer).ExecuteAsync().Result;
            foreach (var vehicle in expandedVehicles)
            {
                Console.WriteLine($"{vehicle.Id} - {vehicle.Manufacturer.Name} {vehicle.Model}");
            }
            #endregion

            Console.ReadLine();
        }
    }
}
