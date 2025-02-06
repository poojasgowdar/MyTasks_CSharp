using System;
namespace Linq_Example
{
    public class Program
    {
        public static void Main()
        {
            // Data source
            string[] names = { "Mango", "Apple", "Chiku", "Watermelon" };

            // LINQ Query 
            var myLinqQuery = from name in names
                              where name.Contains('a')
                              select name;

            // Query execution
            foreach (var name in myLinqQuery)
                Console.Write(name + " ");
            Console.ReadKey();
        }
    }
}