using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 20, 30, 40, 50, 60, 70 };
            Console.WriteLine("Enter the Element to be searched");
            int key = int.Parse(Console.ReadLine());
            int low = 0, high = arr.Length - 1;
            bool found = false;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (arr[mid] == key)
                {
                    Console.WriteLine("Element found at the index " + mid);
                    found = true;
                    break;
                }
                else if (arr[mid] < key)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            if (!found)
            {
                Console.WriteLine("Element not found");
            }
            Console.ReadKey();
        }
    }
}
