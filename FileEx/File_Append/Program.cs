using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Append
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fs = @"C:\CSharp\practise.txt";
            FileStream fp = new FileStream(fs,FileMode.Append);
            byte[] bytedata = Encoding.Default.GetBytes("C# is a programming language");
            fp.Write(bytedata, 0, bytedata.Length);
            fp.Close();
            Console.WriteLine("Successfully saved file with data : C# Is an Object Oriented Programming Language");
            Console.ReadKey();
        }
    }
}
