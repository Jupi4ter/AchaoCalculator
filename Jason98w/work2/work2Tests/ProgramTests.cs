using Microsoft.VisualStudio.TestTools.UnitTesting;
using work2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        //测试
        public void FormulaTest()
        {
            string formula = null;

            formula = Program.formula();

            Assert.IsTrue(formula != null);
        }

        [TestMethod()]
        //Solver函数测试
        public void SolveTest()
        {
            string msg1 = "15*3-5*4";
            string correctAns = "15*3-5*4=25";
            string ans = Program.Solve(msg1);

            Assert.AreEqual(correctAns, ans);
        }

        [TestMethod()]
        //对写入函数Fwrite测试
        public void FwriteTest()
        {
            string msg = "123";
            bool bl = Program.Fwrite(msg);

            Assert.IsTrue(bl);
        }
    }
}