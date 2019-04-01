using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
        {
            Operation operation = new Operation(1);
            int b = operation.GetT_F(5, 45, 1, "*", "-", 0);//初始值quantity[0]=2
            int a = 225;//5 * 45
            if (a == b)
            {
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}