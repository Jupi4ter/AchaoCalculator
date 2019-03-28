using System;
using System.Data;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var seed = Guid.NewGuid().GetHashCode();
            var aRandom = new System.Random(seed);    //设置随机种子
            int num_s = aRandom.Next(2, 4);       //产生符号个数
            int num = num_s + 1;
            string equation = "";
            //将产生的数字和符号存储在字符串中
            for (int i = 0; i < (num + num_s); i++)
            {
                if (i % 2 == 0)
                {
                    equation += aRandom.Next(0, 101).ToString();
                }
                else
                {
                    equation += Program.Getop(aRandom.Next(0, 4)).ToString();
                }
            }
            string test1 = "36*2-50";
            string test2 = "28/4*3";
            string date = equation;
            DataTable dt = new DataTable();
            string really_data = dt.Compute(equation, "false").ToString();
            Assert.AreEqual(Program.Calculate(test1), "22");
            Assert.AreEqual(Program.Calculate(test2), "21");
            Assert.AreEqual(Program.Calculate(equation), really_data);
        }
    }
}
