using System;
using System.Collections.Generic;
namespace CollectionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> cities = new List<string>();
            cities.Add("Bangalore");
            cities.Add("Mysore");
            cities.Add("Hampi");
            cities.Add("Davanagere");
            cities.Add("Mandya");
            cities.Add("Maddhur");

            List<string> newstates = new List<string>();
            newstates.Add("Kerala");
            newstates.Add("Andra Pradesh");
            newstates.Add("Mumbai");

            cities.AddRange(newstates);

            //Accessing Generic List Elements using ForEach Loop

            Console.WriteLine("Accessing Generic List using ForEach loop");
            foreach (var item in cities)
            {
                Console.WriteLine(item);
            }




            //Accessing Generic List Elements using For Loop
            Console.WriteLine("\nAccessing Generic List using For Loop");
            for(int i = 0; i < cities.Count; i++)
            {
                var element = cities[i];
                Console.WriteLine(element);
            }

            //Accessing List Elements by using the Integral Index Position
            Console.WriteLine("\nAccessing Individual List Element by Index Position");
            Console.WriteLine($"First: {cities[0]}");
            Console.WriteLine($"Second: {cities[1]}");
            Console.WriteLine($"Third: {cities[2]}");
            Console.WriteLine($"Fourth: {cities[3]}");
            Console.WriteLine($"Fifth: {cities[4]}");
            Console.WriteLine($"Sixth: {cities[5]}");
            Console.ReadKey();
        }
    }
}
