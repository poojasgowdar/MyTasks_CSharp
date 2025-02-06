using System;
using System.IO;

namespace File_Create
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fs = @"C:\CSharp\practise.txt";
            //Create - Always creates or overwrites the file.
            FileStream fp = new FileStream(fs, FileMode.Create);
            fp.Close();
            Console.WriteLine("File is created");
            Console.ReadKey();


        }
    }
}
