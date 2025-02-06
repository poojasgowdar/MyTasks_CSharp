using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string fp = @"C:\CSharp\project.txt";
            //FileStream fs = new FileStream(fp, FileMode.Create);

            //fs.Close();
            //Console.WriteLine("File created");
            string fn = "newfile.Txt";
            FileStream fs = new FileStream(fn, FileMode.CreateNew);
            fs.Close();
            Console.WriteLine("Created");


            Console.ReadKey();
        }
    }
}
