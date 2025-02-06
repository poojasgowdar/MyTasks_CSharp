using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest
{
    public class SimpleTestCase
    {
        [Fact]
        public void Addition_Two_Num()
        {
            CalculatorOp c = new CalculatorOp();
            int a = 10;
            int b = 20;
            var res = c.Add(a, b);
            //Assert.NotEqual(a, res);
            //Assert.NotEqual(b, res);
            //Assert.Equal(30,res);
            //Assert.NotEqual(-40, res);
            //Assert.NotEqual(50, res);

        }

    }
}
