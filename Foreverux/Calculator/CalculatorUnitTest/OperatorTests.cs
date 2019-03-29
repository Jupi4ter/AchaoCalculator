using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    [TestClass()]
    public class OperatorTests
    {
        [TestMethod()]
        public void OperatorsTest()
        {
            Operator op = new Operator();
            string[] str=op.Operators(3, 4);
            int actual = str[0].Length;
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }
    }
}