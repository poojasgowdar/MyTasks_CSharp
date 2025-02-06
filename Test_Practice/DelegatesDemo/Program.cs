using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    internal class Program
    {
        public delegate void CallbackMethodHandler(string message);
        public static void DoSomework(CallbackMethodHandler del)
        {
            Console.WriteLine("Processing some Task");
            del("Pranaya");
        }
        public void CallbackMethod(string message)//CallBack Function
        {
            Console.WriteLine($"Callback Method Invoked with message: {message}");
        }

        static void Main(string[] args)
        {
            Program obj = new Program();
            CallbackMethodHandler del1 = new CallbackMethodHandler(obj.CallbackMethod);
            //Here, I am calling the DoSomework function and I want the 
            //DoSomework function to call the delegate at some point of time
            //which will invoke the CallbackMethod method
            DoSomework(del1);

            Console.ReadKey();
        }
       
    }
}
