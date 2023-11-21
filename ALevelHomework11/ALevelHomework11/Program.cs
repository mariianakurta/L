using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework11
{
    class Program
    {
        static void Main()
        {
            CustomGenericCollection<string> carCollection = new CustomGenericCollection<string>(5);
            carCollection.Add("Engine", 0);
            carCollection.Add("Battery", 1);
            carCollection.Add("Brakes", 2);
            carCollection.Add("Transmission", 3);
            carCollection.Add("Chassis", 4);

            Console.WriteLine($"Count of collection parts in the collection: {carCollection.Count()}");
            Console.WriteLine();
            Console.WriteLine("Original collection:");
            foreach (var item in carCollection)
            {
                Console.WriteLine(item);
            }

            carCollection.Sort();

            carCollection.SetDefaultAt(1, "Default");
            Console.WriteLine();
            Console.WriteLine("After setting default value at first index:");
            foreach (var item in carCollection)
            {
                Console.WriteLine(item ?? "Default");
            }
        }
    }
}