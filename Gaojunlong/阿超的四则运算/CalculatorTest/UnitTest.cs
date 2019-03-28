
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
namespace CalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
       public void TestMethod1()
        {
            Calculator calculator = new Calculator();
            int fhlen = calculator.Genelment();
            string _ = calculator.Gensign(fhlen);
            int result = calculator.Genresult();
            string timu = calculator.Gettimu();
            int isok = calculator.Getisok();
        }
    }
}
