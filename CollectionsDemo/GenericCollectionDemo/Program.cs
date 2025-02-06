using System;
using System.Collections.Generic;


namespace GenericCollectionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> countries = new List<string>
            { 
                "India",
                "Japan",
                "China",
                "UK"
            };
            //Accessing elements using foreach loop
            Console.WriteLine("Accessing using foreach loop");
            foreach(string country in countries)
            {
                Console.WriteLine(country);
            }
            

            //Accessing elements using for loop
            Console.WriteLine("Accessing using for loop");
            for(int i = 0; i < countries.Count; i++)
            {
                string ele = countries[i];
                Console.WriteLine(ele);
                //Console.WriteLine(i + " " + countries[i]);
            }

            //Accessing elements individually 
            Console.WriteLine($"First: {countries[0]}");
            Console.WriteLine($"Second: {countries[1]}");
            Console.WriteLine($"Third: {countries[2]}");
            Console.WriteLine($"Fourth: {countries[3]}");
            Console.ReadKey();
        }
    }
}
