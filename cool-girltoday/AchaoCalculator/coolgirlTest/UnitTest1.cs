using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coolgirlTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        
        public void ProblemTest()
        {
            Problem problem = new Problem(1);
            problem.arr[0] = 7;
            problem.arr[1] = 3;
            problem.op[0] = '+';
            string ret = problem.SolveAndCheck(1);
            Assert.AreEqual(ret, "7+3=10");
        }
    }
}
