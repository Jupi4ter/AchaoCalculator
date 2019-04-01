using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;
using System.IO;

namespace 四则运算
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            DataTable datatable = new DataTable();
            int num1, num2, num3, num4, oper1, oper2, oper3;
            int n;
            Console.Write("请输入题数：");
            n = Convert.ToInt32(Console.ReadLine());//输入需要生成的四则运算的数量
            int m;
            int count = 0;
            while (count < n)
            {
                m = rd.Next(2, 4);//随机生成运算符个数
                if (m == 2)//运算符个数是两个
                {
                    num1 = rd.Next(1, 101);
                    num2 = rd.Next(1, 101);
                    num3 = rd.Next(1, 101);
                    oper1 = rd.Next(0, 4);
                    oper2 = rd.Next(0, 4);
                    if (three_num(num1, num2, num3, oper1, oper2) != -1)
                    {
                        count++;//当生成的四则运算满足条件时count+1，否则重新生成
                    }
                }
                else if (m == 3)//运算符个数是三个
                {
                    num1 = rd.Next(1, 101);
                    num2 = rd.Next(1, 101);
                    num3 = rd.Next(1, 101);
                    num4 = rd.Next(1, 101);
                    oper1 = rd.Next(0, 4);
                    oper2 = rd.Next(0, 4);
                    oper3 = rd.Next(0, 4);
                    if (four_num(num1, num2, num3, num4, oper1, oper2, oper3) != -1)
                    {
                        count++;// 当生成的四则运算满足条件时count + 1，否则重新生成
                    }
                }
            }
            Console.ReadKey();
        }

        static public double three_num(int num1, int num2, int num3, int a, int b)
        {
            string[] oper = new string[] { "+", "-", "*", "/" };
            DataTable dt = new DataTable();
            double answer = Convert.ToDouble(dt.Compute((num1.ToString() + oper[a] + num2.ToString() + oper[b] + num3.ToString()), "false"));
            string equation = (num1.ToString() + oper[a] + num2.ToString() + oper[b] + num3.ToString() + "=" + answer.ToString() + "\n");//将生成的算式存入字符串
            if (Convert.ToDouble(Convert.ToInt32(answer)) == answer && answer >= 0)//判断结果不含小数且不为复数
            {
                Console.WriteLine(equation);
                File.AppendAllText(@"C:\Users\Mac\Desktop\subject.txt", equation + "\r\n");//输出到文件
                return answer;
            }
            else
            {
                return -1;
            }
        }
        static public double four_num(int num1, int num2, int num3, int num4, int a, int b, int c)
        {
            string[] oper = new string[] { "+", "-", "*", "/" };
            DataTable dt = new DataTable();
            double answer = Convert.ToDouble(dt.Compute((num1.ToString() + oper[a] + num2.ToString() + oper[b] + num3.ToString() + oper[c] + num4.ToString()), "false"));
            string equation = (num1.ToString() + oper[a] + num2.ToString() + oper[b] + num3.ToString() + oper[c] + num4.ToString() + "=" + answer.ToString() + "\n");//将生成的算式存入字符串
            if (Convert.ToDouble(Convert.ToInt32(answer)) == answer && answer >= 0)//判断结果不含小数且不为复数
            {
                Console.WriteLine(equation);
                File.AppendAllText(@"C:\Users\Mac\Desktop\subject.txt", equation + "\r\n");//输出到文件
                return answer;
            }
            else
            {
                return -1;
            }
        }
    }
}

