using Microsoft.VisualStudio.TestTools.UnitTesting;
using JISUANQI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JISUANQI.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void ResultTest()
        {
            double x = 5;
            double y = 4;
            string res = Convert.ToString(Program.Result(x, y, 3));
            string z = "20";
            Assert.AreEqual(res, z);
        }

        [TestMethod()]
        public void SuiJiShuTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SuiJiFuHaoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RESTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SuiJiTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ResultTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void OPTest()
        {
            string a = "/";
            string b = Program.OP(4);           
            Assert.AreEqual(a,b);
        }

        [TestMethod()]
        public void SuiJiShuTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SuiJiFuHaoTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RESTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SuiJiTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ResultTest2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void OPTest1()
        {
            Assert.Fail();
        }
    }
}