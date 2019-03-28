using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
namespace ConsoleApp3
{
	public class Program
	{
		public static string makeformula()//创建等式
		{
			StringBuilder sb = new StringBuilder();
			String[] op = { "+", "-", "*", "/" };
			var seed = Guid.NewGuid().GetHashCode();
			Random rd = new Random(seed);
			int count = rd.Next(1, 3);
			int start = 0;
			int num1 = rd.Next(0, 101);
			sb.Append(num1);
			while (start <= count)
			{
				int operation = rd.Next(0, 4); // 生成符号
				int number2 = rd.Next(0, 101);
				sb.Append(op[operation]).Append(number2);
				start++;
			}
			return sb.ToString();

		}
		/*public static String Solve(String formula)  //计算等式
		{
			Stack<String> tempStack = new Stack<string>();//存数字或符号
			Stack<char> operatorStack = new Stack<char>();//存符号
			int len = formula.Length;
			int k = 0;
			for (int j = -1; j < len - 1; j++)
			{
				char formulaChar = formula.ElementAt(j + 1);
				if (j == len - 2 || formulaChar == '+' || formulaChar == '-' || formulaChar == '/' || formulaChar == '*')
				{
					if (j == len - 2)
					{
						tempStack.Push(formula.Substring(k));
					}
					else
					{
						if (k < j)
						{
							tempStack.Push(formula.Substring(k, j+1));
						}
						if (operatorStack.Count == 0)
						{
							operatorStack.Push(formulaChar); //if operatorStack is empty, store it
						}
						else
						{
							char stackChar = operatorStack.Peek();
							if ((stackChar == '+' || stackChar == '-')
									&& (formulaChar == '*' || formulaChar == '/'))
							{
								operatorStack.Push(formulaChar);
							}
							else
							{
								tempStack.Push(operatorStack.Pop().ToString());
								operatorStack.Push(formulaChar);
							}
						}
					}
					k = j + 2;
				}
			}
			while (!(operatorStack.Count == 0))
			{ // Append remaining operators
				tempStack.Push(operatorStack.Pop().ToString());
			}
			Stack<String> calcStack = new Stack<string>();
			for (int i = 0; i < tempStack.Count; i++)
			{ // Reverse traversing of stack
				string peekChar = tempStack.Peek();
				if (!peekChar.Equals("+") && !peekChar.Equals("-") && !peekChar.Equals("/") && !peekChar.Equals("*"))
				{
					calcStack.Push(peekChar); // Push number to stack
				}
				else
				{
					int a1 = 0;
					int b1 = 0;
					if (calcStack.Count != 0)
					{
						b1 = Convert.ToInt32(calcStack.Pop());
					}
					if (calcStack.Count != 0)
					{
						a1 = Convert.ToInt32(calcStack.Pop());
					}
					switch (peekChar)
					{
						case "+":
							calcStack.Push(String.Copy((a1 + b1).ToString()));
							break;
						case "-":
							calcStack.Push(String.Copy((a1 - b1).ToString()));
							break;
						case "*":
							calcStack.Push(String.Copy((a1 * b1).ToString()));
							break;
						default:
							calcStack.Push(String.Copy((a1 / b1).ToString()));
							break;
					}
				}
			}
			return formula + "=" + calcStack.Pop();
		}*/
		public static string Solve(string a)
		{
			DataTable dt = new DataTable();
			Object ob;
			ob = dt.Compute(a, "");
			while (ob.ToString().Contains(".") || a.Contains("/0") || Convert.ToInt32(ob) < 0)
			{
				a = makeformula();
				ob = dt.Compute(a, "");
			}
			return a + "=" + ob.ToString();
		}
		public static void Main(string[] args)
		{
			//string question = makeformula();
			//Console.WriteLine(question);
			int n;
			Console.WriteLine("请输入你想产生几道题");
			n = int.Parse(Console.ReadLine());
			StreamWriter sw = new StreamWriter(@"C:\Users\李文毅\AchaoCalculator\subject.txt");
			for (int i = 0; i < n; i++)
			{
				string a = makeformula();
				String ret = Solve(a);
				Console.WriteLine(ret);

				sw.WriteLine(ret);

				a = null;
				ret = null;
			}
			sw.Close();
			/*string a = makeformula();
			String ret = Solve(a);
			Console.WriteLine(ret);*/
		}
	}
}
