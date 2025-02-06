using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_ex_opnorcreate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //OpenOrCreate- Opens the file if it exists, otherwise creates a new one.
            string fs = @"C:\CSharp\magic.txt";
            FileStream fp = new FileStream(fs, FileMode.OpenOrCreate);
            fp.Close();
            Console.WriteLine("File exist/opened");
            Console.ReadKey();


        }
    }
}
