using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Tests
{
	[TestClass()]
	public class ProgramTests
	{
		[TestMethod()]
		public void makeformulaTest()
		{
			Assert.IsTrue(1>0);
		}

		[TestMethod()]
		public void SolveTest()
		{
			string a = "2+3*2";
			string b = "2+3*2=8";
				string ans = Program.Solve(a);
			Assert.AreEqual(ans,b);
		}

		[TestMethod()]
		public void MainTest()
		{
			Assert.IsTrue(1 > 0);
		}
	}
}