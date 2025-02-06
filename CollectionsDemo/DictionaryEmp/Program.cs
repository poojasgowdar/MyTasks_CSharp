using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryEmp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<int, String>()
            {
                {1, "Brinjal"},
                {2, "Tomato" },
                {3, "Pumpkin" },
                {4, "Onion" }

            };
            //dictionary.Remove(3);

            
            //Console.WriteLine(dictionary.Count);
            dictionary.Add(5,"Raddish");
            Console.WriteLine(dictionary.ContainsValue("Pumpkin"));
            Console.WriteLine(dictionary.ContainsKey(3));

            var copyDictionary = new Dictionary<int, string>(dictionary);
            foreach (var v in copyDictionary)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine(dictionary.TryGetValue(4, out string value) && value == "Onion");
            Console.WriteLine(dictionary.GetValueOrDefault(4));
            foreach (var item in dictionary)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }

    public static class DictionaryExtensions
    {
        public static tvalue GetValueOrDefault<tkey, tvalue>(this Dictionary<tkey, tvalue> dictionary, tkey key, tvalue defaultValue = default)
        {
            if (dictionary.TryGetValue(key, out tvalue value))
            {
                return value;
            }
            else
            {
                return defaultValue;
            }
        }

    }
}
