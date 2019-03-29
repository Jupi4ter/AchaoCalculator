using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GreatCalculationTest()
        {
            string a = "3*15";
            string b = Program.Calculation(a);
            string c = "3*15=45";
            Assert.AreEqual(b,c);
         }
    }
}