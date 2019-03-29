using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using 四则运算生成器;
using System.Collections.Generic;


namespace CalculatorUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Subject sb = new Subject();
            List<double> num = new List<double> { 1, 2, 3 , 4};
            List<int> symbol = new List<int> { 0, 0, 2 };
            sb.set(num, symbol);
            double r = Program.CalculateResult(sb).result;
            Assert.AreEqual(r, 15);
        }
        [TestMethod]
        public void TestMethod2()
        {
            int a=0;
            string result = Program.whichSymbol(a);
            Assert.AreEqual(result, "+");
            a = 1;
            result = Program.whichSymbol(a);
            Assert.AreEqual(result, "-");
            a = 2;
            result = Program.whichSymbol(a);
            Assert.AreEqual(result, "*");
            a = 3;
            result = Program.whichSymbol(a);
            Assert.AreEqual(result, "/");
        }
        [TestMethod]
        public void TestMethod3()
        {
            int symbol = 0;
            double a = 6, b = 3;
            double result = Program.Calculate(symbol, a, b);
            Assert.AreEqual(result, 9);
            symbol = 1;
            result = Program.Calculate(symbol, a, b);
            Assert.AreEqual(result, 3);
            symbol = 2;
            result = Program.Calculate(symbol, a, b);
            Assert.AreEqual(result, 18);
            symbol = 3;
            result = Program.Calculate(symbol, a, b);
            Assert.AreEqual(result, 2);
        }
        [TestMethod]
        public void TestMethod4()
        {

        }
    }
}
