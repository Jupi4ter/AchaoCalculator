using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private char[] operators = new char[3];
        private int[] digitals = new int[4];
        [TestMethod]
        //该函数用于测试操作符数组和数字数组能否被赋值
        public void AssignCharactorsTest()
        {
            Program.AssignCharactors(3,ref operators,ref digitals);
            bool isDigitalsAssigned = DigitalsAssignTest(digitals);
            Assert.IsTrue(operators!= null&&isDigitalsAssigned);

        }
        //该函数用于测试数字数组能否被赋值，能则返回true，否则返回false
        public bool DigitalsAssignTest(int[] digitals)
        {
            //如果数字数组全部都是0，则没有被赋值
            for (int i = 0; i < digitals.Length; i++)
            {
                if (digitals[i] != 0)
                {
                    return true;
                }
            }
            return false;
        }
        [TestMethod]
        //该函数用于测试能否正确识别连续的除法是否产生小数
        public void IsDivisibleTest()
        {
            char[] operatorsForTest = new char[] { '/', '/', '/' };
            int[] digitalsForTest = new int[] { 65, 15, 3, 7 };
            int first = 0;
            Assert.IsFalse(Program.IsDivisible(ref first, operatorsForTest, digitalsForTest, 2));
        }
        [TestMethod]
        //该函数用于测试能否正确合成字符串
        public void GetCommandTest()
        {
            char[] operatorsForTest = new char[] { '/', '/', '/' };
            int[] digitalsForTest = new int[] { 65, 15, 3, 7 };
            Assert.IsTrue(Program.GetCommand(operatorsForTest, digitalsForTest) == "65/15/3/7");
        }




    }
}
