using System;
using System.IO;
namespace File_Truncate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //truncate-Opens the file and erases its content.
            string fs = @"C:\CSharp\practise.txt";
            FileStream fp = new FileStream(fs, FileMode.Truncate);
            fp.Close();
            Console.WriteLine("The data is removed");
            Console.ReadKey();


        }
    }
}
