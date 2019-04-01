using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication2;


namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        
        public void MakeFormulaTest()
        {
            string formula = null;

            formula = Program.MakeFormula();

            Assert.IsTrue(formula != null);
        }

        [TestMethod()]
        public void SolveTest()
        {
            string msg1 = "1+2*3-4";
            string correctAns = "1+2*3-4=3";
            string ans = Program.Solve(msg1);

            Assert.AreEqual(correctAns, ans);
        }
        

        
    }
}
