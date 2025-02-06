using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Level_Inheritance
{
    public class University
    {
        public string Name { get; set; }

        public University()
        {
            Name = "Davanagere University";
        }
        public void ConductExams()
        {
            Console.WriteLine("VTU conducts an Exam");
        }
    }
    public class College:University
    {
        public string Name { get; set; }
        public College()
        {
            Name = "UBDT";
        }
        public void FreshersParty()
        {
            Console.WriteLine("College Conducts an Freshers Party ");
        }
    }
    public class Mca:College
    {
        public string Subject { get; set; }
        public Mca()
        {
            Subject = "Java";
        }
        public void CSharp()
        {
            Console.WriteLine("CSharp is a good Subject ");
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Mca m = new Mca();
            Console.WriteLine("The University Name is: " + m.Name);
            Console.WriteLine("The College Name is: " + m.Name);
            Console.WriteLine("The subject Name is: " + m.Subject);
            m.ConductExams();
            m.FreshersParty();
            m.CSharp();
            Console.ReadKey();
        }

    }
}
