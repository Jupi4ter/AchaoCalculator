using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
namespace test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program cc = new Program();
            int opcount;
            opcount = 2;
            int[] number = new int[3];
            char[] opp = new char[2];
            number[0] = 1;
            number[1] = 2;
            number[2] = 3;
            opp[0] = '+';
            opp[1] = '+';
            Assert.AreEqual(Program.P(opcount, number, opp), 1);

        }
    }
}
