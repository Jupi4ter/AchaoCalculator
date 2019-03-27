using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;

namespace UnitTestcalculator
{   
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            caculator ca = new caculator();
            string[] s = new string[] {"1","-","5","*","8" };
            Assert.IsTrue(ca.compute(s)==-1);
        }
        [TestMethod]
        public void TestMethod2()
        {
            caculator ca = new caculator();
            string[] s = new string[] { "1", "+", "5", "*", "8" };
            Assert.IsTrue(ca.compute(s) == 41);
        }
        [TestMethod]
        public void TestMethod3()
        {
            caculator ca = new caculator();
            string[] s = new string[] { "1", "/", "5", "*", "8" };
            Assert.IsTrue(ca.compute(s) == -1);
        }
        [TestMethod]
        public void TestMethod4()
        {
            caculator ca = new caculator();
            string[] s = new string[] { "5", "/", "1", "*", "8" };
            Assert.IsTrue(ca.compute(s) == 40);
        }
        [TestMethod]
        public void TestMethod5()
        {
            caculator ca = new caculator();
            string[] s = new string[] { "1", "*", "5", "+", "8" };
            Assert.IsTrue(ca.compute(s) == 13);
        }
    }
}
