using System;
using System.Collections.Generic;
using System.Linq;


namespace GenericDictionaryDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionaryStates = new Dictionary<string, string>()
            {
                { "Karnataka", "Bangalore" },
                { "Mumbai", "Thane" },
                { "Delhi", "Agra" }
            };
            //dictionaryStates.Add("Karnataka", "Bangalore");
            //dictionaryStates.Add("Mumbai", "Thane");
            //dictionaryStates.Add("Delhi", "Agra");
            //dictionaryStates.Add("Kashmir", "Nepal");

            //Accessing using foreach Loop
            Console.WriteLine("Accessing using foreach loop ");
            foreach(KeyValuePair<string,string> dic in dictionaryStates)
            {
                //Console.WriteLine($"Key:{dic.Key},Value:{dic.Value}");
                Console.WriteLine(dic.Value);
            }

            //Accessing using keys
            Console.WriteLine("\nAccessing Elements using Keys");
            Console.WriteLine(dictionaryStates["Karnataka"]);

            //Accesing using for loop
            Console.WriteLine("\nAccessing Elements using for loop");
            for(int i = 0; i < dictionaryStates.Count; i++)
            {
                string key = dictionaryStates.Keys.ElementAt(i);
                string value = dictionaryStates[key];
                Console.WriteLine($"Key: {key}, Value: {value}");
            }
            Console.ReadKey();
        }
    }
}
