using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorOp
    {
        public int Add(int a,int b)
        {
            var res =a + b;
            return res;
        }
        public int Sub(int a,int b)
        {
            var res= a - b;
            return res;
        }
    }
}
