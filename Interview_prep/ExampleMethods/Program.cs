using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMethods
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Replace Method
            //string str1 = "Good Morning Pooja";
            //string substr = str1.Replace("Pooja", "Pradeep");
            //Console.WriteLine(substr);

            //substring Method
            //string str1="Good Morning Pooja";
            //string substr = str1.Substring(5, 13);
            //Console.WriteLine(substr);

            //ToUpper 
            //string str1 = "good morning";
            //string s = str1.ToUpper();
            //Console.WriteLine(s);
            //Console.ReadKey();

            //ToLower
            //string str1 = "GOOD MORNING";
            //string s = str1.ToLower();
            //Console.WriteLine(s);
            //Console.ReadKey();

            //Indexof
            //string str = "Pooja";
            //int s = str.IndexOf("j");
            //Console.WriteLine(s);
            //Console.ReadKey();

            //split
            string str = "apple,banana,cherry";
            string[] fruits = str.Split(',');
            foreach(string fruit in fruits)
            {
                Console.WriteLine(fruit);
            }
            
            Console.ReadKey();
           
        }
    }
}
