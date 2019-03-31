using Microsoft.VisualStudio.TestTools.UnitTesting;
using zqhomework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zqhomework.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        

        [TestMethod()]
        public void ansxTest()
        {
            bool s = true;
            Assert.AreEqual(s, Program.ansx(3));
           // Assert.Fail();
        }

        [TestMethod()]
        public void counterTest()
        {
            int expect = 3;
             int act=Convert.ToInt32( Program.counter(1, 2, 0));
            Assert.AreEqual(expect, act);
           // Assert.Fail();
        }
    }
}