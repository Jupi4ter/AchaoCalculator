using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入题目数量");
            int n = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if (n <= 0)
                {
                    Console.WriteLine("输入错误，请重新输入题目数量");
                    n = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            string[] equaStrings = new string[n];
            int j = 0;
            for (int i = 0; i < n; i++)
            {
                string equation = Calculation();
                string really_data = Calculate(equation);
                double data = Convert.ToDouble(really_data);
                //判断算式是否满足要求
                if (data < 0 || (data % 2 != 0 && data % 2 != 1))
                {
                    i--;
                }
                else
                {
                    string Date = equation + "=" + really_data;
                    equaStrings[j++] = Date;
                }
            }
            //输出到文件
            Output_txt(equaStrings);
        }
        public static string Getop(int x)
        {
            string op = "";
            if (x == 0)
            {
                op = "+";
            }
            else if (x == 1)
            {
                op = "-";
            }
            else if (x == 2)
            {
                op = "*";
            }
            else
            {
                op = "/";
            }

            return op;
        }

        public static string Calculation()
        {
            var seed = Guid.NewGuid().GetHashCode();
            var aRandom = new System.Random(seed);    //设置随机种子
            int num_s = aRandom.Next(2, 4);       //产生符号个数
            int num = num_s + 1;
            string equation = "";
            //将产生的数字和符号存储在字符串中
            for (int i = 0; i < (num + num_s); i++)
            {
                if (i % 2 == 0)
                {
                    equation += aRandom.Next(0, 101).ToString();
                }
                else
                {
                    equation += Getop(aRandom.Next(0, 4)).ToString();
                }
            }

            return equation;
        }
        public static string Calculate(string equation)
        {
            DataTable dt = new DataTable();
            string really_data = dt.Compute(equation, "false").ToString();

            return really_data;
        }

        public static void Output_txt(string[] eqution)
        {
            StreamWriter sw = new StreamWriter(@"E:\3\git\AchaoCalculator\leerijin\subject.txt");
            Console.SetOut(sw);
            foreach (var i in eqution)
            {
                Console.WriteLine(i);
            }
            sw.Flush();
            sw.Close();
        }
    }
}
