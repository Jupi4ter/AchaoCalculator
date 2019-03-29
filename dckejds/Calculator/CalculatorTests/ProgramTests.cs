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
    public class ProgramTests
    {
        [TestMethod()]
        public void CalculateTest()
        {
            //测试函数Calculate(string question)
            string question1 = "8/2+5*4";
            string ans = "8/2+5*4=24";
            string answer = Program.Calculate(question1);
            Assert.AreEqual(ans,answer);
            //Assert.Fail();
        }
    }
}