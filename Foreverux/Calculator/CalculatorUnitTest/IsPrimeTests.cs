using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    [TestClass()]
    public class IsPrimeTests
    {
        [TestMethod()]
        public void isPrimeTest()
        {
            bool expected = true;
            IsPrime isPrime = new IsPrime();
            bool actual = isPrime.isPrime(7);
            Assert.AreEqual(expected, actual);
        }
    }
}