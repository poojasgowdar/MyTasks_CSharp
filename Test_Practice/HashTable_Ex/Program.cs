using System;
using System.Collections;

namespace HashTable_Ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, "One");
            hashtable.Add("Eid", "Festival");
            hashtable.Add("Salary", 3500);
            foreach(DictionaryEntry entry in hashtable)
            {
                Console.WriteLine($"Key:{entry.Key}, Value:{entry.Value}");
            }
            //accessing by using key
            Console.WriteLine("Salary:" + hashtable["Salary"]);
            Console.ReadKey();
        }
    }
}
