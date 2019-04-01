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
        public void ExamTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void operationTest()

        { 
            string equation = "6*7-4";
            string ans = "6*7-4=38";
            string answer = Program.operation(equation);
            Assert.areequal(ans,answer);
        }
    }
}