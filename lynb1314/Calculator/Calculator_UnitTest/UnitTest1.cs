using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()//测试函数Calculate(string formula)
        {
            string formula = "60/10+60";
            string result = "66";
            string Test_result = Program.Calculate(formula);

            Assert.AreEqual(result, Test_result);
        }
    }
}
