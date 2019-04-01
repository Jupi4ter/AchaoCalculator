using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using compute;


namespace ASUnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int text1 = 10;
            int text2 = 5;
            int text3 = 3;
            Calculation calc = new Calculation(text1, text2, text3);
            //string ret = 
            Assert.AreEqual(calc.mathjia(), "10＋5－3=!12");
        }
    }
}
