using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTestCase
{
    [TestFixture]
    public class CalculatorTestCase
    {
        [TestFixture]
        public class CalculatorTests
        {
            private Program program;

            [SetUp]
            public void Setup()
            {
                program = new Program();
            }

            [Test]
            public void Add_ReturnsCorrectSum()
            {
                int result = program.Add(3, 2);
                Assert.AreEqual(5, result);
            }

            [Test]
            public void Subtract_ReturnsCorrectDifference()
            {
                int result = program.Sub(5, 2);
                Assert.AreEqual(3, result);
            }

            [Test]
            public void Multiply_ReturnsCorrectProduct()
            {
                int result = program.Mul(4, 2);
                Assert.AreEqual(8, result);
            }

            [Test]
            public void Divide_ReturnsCorrectQuotient()
            {
                int result = program.Div(10, 2);
                Assert.AreEqual(5, result);
            }

            [Test]
            public void Divide_ByZero_ThrowsException()
            {
                Assert.Throws<DivideByZeroException>(() => program.Div(10, 0));
            }
        }
    }
}
