using System;
   class Test
    {
        public void Add(int a,int b)
        {
        Console.WriteLine(a + b);
        }

        public void Sub(int a, int b)
        {
        Console.WriteLine(a - b);
        } 
    }

    public delegate void dname(int a,int b);
    public delegate void dname1(int a,int b);
   class Program
    {
        static void Main(string[] args)
        {
        Test t = new Test();
        dname d = new dname(t.Add);
        dname1 d1 = new dname1(t.Sub);
      
        d(10, 20);
        d1(20, 10);
       
        Console.ReadKey();
        }
    }

