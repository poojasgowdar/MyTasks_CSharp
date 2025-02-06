using System;
namespace EnumEx2
{

    enum days
    {
        mon,
        tue,
        wed,
        thur,
        fri,
        sat
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine((int)days.mon);
            Console.WriteLine((int)days.wed);

            //foreach(string s in days)
            //{
            //    Console.WriteLine(s);
            //}
            Console.ReadKey();
        }
    }
}
