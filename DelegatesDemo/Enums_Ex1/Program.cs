using System;
namespace Enums_Ex1
{

    public enum DayOfWeek
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DayOfWeek today = DayOfWeek.Wednesday;

            if(today== DayOfWeek.Tuesday)
            {
                Console.WriteLine("Today is Tuesday");
            }
            else
            {
                Console.WriteLine("Today is not Tuesday");
            }

            Console.WriteLine("Days of the Week:");
            foreach(DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine(day);
            }
            Console.ReadKey();
        }
    }
}
