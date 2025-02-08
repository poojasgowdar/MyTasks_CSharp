using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MethodInjection
{
    public interface IDocument
    {
        void Print();
    }
    public class WordDocument : IDocument
    {
        public void Print()
        {
            Console.WriteLine("Printer is Flexible");
        }
    }

    public class Program
    {
        public void PrintDocument(IDocument document)
        {
            document.Print();
        }
    }

    public class Example
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            IDocument doc = new WordDocument();
            p.PrintDocument(doc);
            Console.ReadKey();

        }
    }
}
