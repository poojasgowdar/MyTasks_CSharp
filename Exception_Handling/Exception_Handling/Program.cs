using System;
using System.Linq.Expressions;


namespace Exception_Handling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                //1.videByZeroException
                //Console.WriteLine("Enter the first number:");
                //n1 = int.Parse(Console.ReadLine());
                //Console.WriteLine("Enter the Second number:");
                //n2 = int.Parse(Console.ReadLine());
                //n3 = n1 / n2;
                //Console.WriteLine(n3);

                //2.IndexOutOfRangeException
                //Console.WriteLine(arr[1]);

                //3.FormatException
                //int x = int.Parse("abc");

                ////4.NullReferenceException
                //String str = null;
                //Console.WriteLine(str.Length);

                //5.Invalid cast exception
                object obj = "Hello";
                int num = (int)obj;

            }
            //catch (DivideByZeroException e)
            //{
            //    Console.WriteLine("Cant divide by zero" +e.Message);
            //}

            //catch (FormatException e)
            //{
            //    Console.WriteLine("Enter Only Integer Numbers" +e.Message);
            //}

            //catch(NullReferenceException e)
            //{
            //    Console.WriteLine("Null Reference Error:" +e.Message);
            //}

            //catch (IndexOutOfRangeException e)
            //{
            //    Console.WriteLine("Index is Out of Range");
            //}

            catch(InvalidCastException e)
            {
                Console.WriteLine("Invalid Cast Error:" + e.Message);
            }

            //catch(Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            
            Console.ReadKey();
         }
    }
}
