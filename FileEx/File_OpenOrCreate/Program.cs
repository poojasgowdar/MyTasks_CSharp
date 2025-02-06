using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_OpenOrCreate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string fileName = "myfile.txt";
            //FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            //byte[] data = Encoding.UTF8.GetBytes("Hello, Canada!");
            //fs.Write(data, 0, data.Length);


            //Console.WriteLine("File opened or created successfully.");
            //fs.SetLength(0);

            //Console.WriteLine("File Truncated Successully");
            //byte[] data1 = Encoding.UTF8.GetBytes("\nThis is appended text.");
            //fs.Write(data, 0, data.Length);
            //Console.WriteLine("Data appended to the file successfully.");

            string fileName = "my.txt";
            FileStream fs = new FileStream(fileName, FileMode.Open);
            Console.WriteLine("File Opened");
            fs.Close();

            Console.ReadKey();
        }
    }
}
