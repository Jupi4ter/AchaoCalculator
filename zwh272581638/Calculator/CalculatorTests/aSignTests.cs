using Microsoft.VisualStudio.TestTools.UnitTesting;
using calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator.Tests
{
    [TestClass()]

    public class aSignTests
    {
        
        [TestMethod()]
        public void SignTest()
        {
            int a = 1;
            aSign x = new aSign();
            string b = x.Sign(a);
            string exp = "+";
            Assert.AreEqual(exp, b);
        }
    }
}