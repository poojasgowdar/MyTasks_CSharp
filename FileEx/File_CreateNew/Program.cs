using System;
using System.IO;
namespace File_CreateNew
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CreateNew - Creates a new file, throwing an error if the file exists.
            string fs = @"C:\CSharp\practise.txt";
            FileStream fp = new FileStream(fs, FileMode.CreateNew);
            fp.Close();
            Console.WriteLine("File is opened");
            Console.ReadKey();

        }
    }
}
