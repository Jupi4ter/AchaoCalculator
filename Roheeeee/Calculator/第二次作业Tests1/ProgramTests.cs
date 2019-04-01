using Microsoft.VisualStudio.TestTools.UnitTesting;
using 第二次作业;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第二次作业.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void operationTest()
        {
            string equation = "6*7-4";
            string correct = "6*7-4=38";
            string ans = Program.operation(equation);
            Assert.AreEqual(correct,ans);
        }
    }
}