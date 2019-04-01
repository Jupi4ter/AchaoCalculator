using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;

namespace CalculatorUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int num1 = -100;
            int num2 = 200;
            
            Assert.AreEqual(Program.Add(num1, num2), 100);

        }
    }
}
