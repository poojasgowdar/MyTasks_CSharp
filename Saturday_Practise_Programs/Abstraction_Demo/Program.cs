using System;
using System.Collections.Generic;
namespace Abstraction_Demo
{
    abstract class Animal
    {
        public abstract void sleep();
        public abstract void play();
    }

    abstract class Cat : Animal
    {
        public override void sleep()
        {
            Console.WriteLine("Cat says Meow");
        }
    }
    class Dog : Cat
    {
        public override void sleep()
        {
            Console.WriteLine("Dog says Boww");
        }

        public override void play()
        {
            Console.WriteLine("Dog is Playing");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Dog d = new Dog();
            
            d.sleep();
            d.play();
            


            Console.ReadKey();
        }
    }

}
