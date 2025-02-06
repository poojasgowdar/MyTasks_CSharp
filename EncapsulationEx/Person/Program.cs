using System;


namespace Person
{
    internal class Program
    {
        private string name;
        private int age;

        //public property for Name
        public string Name
        {
            get { return name; }// read
            set { name = value; } //write

        }

        //public property for Age
        public int Age
        {
            get { return age; }
            set
            {
                if(value>=0)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("Age cannot be negative");
                }
            }
        }

        public void Display()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }


        class Man 
        {
            static void Main(string[] args)
            {
               Program p = new Program();
               Console.WriteLine("=======================");
               Console.WriteLine("Enter your Name:");
               p.Name = Console.ReadLine();

               Console.WriteLine("Enter your Age:");
               while (true)
               {
                   if(int.TryParse(Console.ReadLine(),out int age))
                   {
                    p.Age = age;
                    break;

                   }
                   else
                   {
                    Console.Write("Invalid input, Please enter a valid age");
                   }

                p.Display();
               }
            Console.ReadKey();

             }
        }
     
    
}
