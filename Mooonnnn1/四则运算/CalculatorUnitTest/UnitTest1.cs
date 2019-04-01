using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using 四则运算;

namespace CalculatorUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()//测试three_num函数
        {
            int num1=4, num2=2, num3=4, oper1=0, oper2=1;
            string[] oper = new string[] { "+", "-", "*", "/" };
            Assert.AreEqual(Program.three_num(num1, num2, num3, oper1, oper2), Convert.ToDouble(2));
        }
        [TestMethod]
        public void TestMethod2()//测试four_num函数
        {
            int num1 = 16, num2 = 3, num3 = 2, num4 = 2, oper1 = 0, oper2 = 1, oper3 = 2;
            string[] oper = new string[] { "+", "-", "*", "/" };
            Assert.AreEqual(Program.four_num(num1, num2, num3, num4, oper1, oper2, oper3), Convert.ToDouble(15));
        }
    }
}