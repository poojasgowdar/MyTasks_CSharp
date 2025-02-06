using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string word= "Good morning.Have a nice day";

            //string result = word.Substring(20,8);
            //Console.WriteLine(result);

            string word2="Good afternoon Alexa";
            string word = word2.Replace("afternoon", "morning");
            Console.WriteLine(word);
            
            Console.ReadKey();  

        }
    }
}
