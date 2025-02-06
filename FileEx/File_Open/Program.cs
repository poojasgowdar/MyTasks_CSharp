using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Open
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Open - Only opens an existing file
            string fs = @"C:\CSharp\practise.txt";
            FileStream fp = new FileStream(fs, FileMode.Open);
            fp.Close();
            Console.WriteLine("File is Opened");
            Console.ReadKey();
        }
    }
}
