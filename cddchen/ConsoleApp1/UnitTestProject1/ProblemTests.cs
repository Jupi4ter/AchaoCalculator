using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class ProblemTests
    {
        [TestMethod()]
        public void ProblemTest()
        {
            Problem problem = new Problem();
            problem.arr[0] = 11;
            problem.arr[1] = 22;
            problem.op[0] = '+';
            string ret = problem.SolveAndCheck(1);
            Assert.AreEqual(ret, "11+22=33");
        }
    }
}