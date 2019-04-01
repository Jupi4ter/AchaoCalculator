
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ConsoleApp1
{

    class Program
    {
        public static string Create()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());//采用guide作为种子，不产生重复的随机数
            string[] op = new string[] { "+", "-", "*", "/" };//存符号的字符串
            int op_count = random.Next(2, 4);//随机生成2-3个运算符
            int[] number = new int[op_count + 1];
            StringBuilder express = new StringBuilder();//用stringbuilder在字符串后进行添加

            for (int i = 0; i <= op_count; i++)
            {
                number[i] = random.Next(10) + 1;//+1避免出现0
            }

            for (int i = 0; i < op_count; i++)
            {
                int op_choose = random.Next(4);//利用数组下标随机选取某个运算符
                express.Append(Convert.ToString(number[i]) + Convert.ToString(op[op_choose]));
                if (op_choose == 3)
                {
                    number[i + 1] = Judge(number[i], number[i + 1]);
                }
            }

            express.Append(Convert.ToString(number[op_count]));
            return express.ToString();
        }

        public static int Judge(int x, int y)//判断有无小数
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            if (x % y != 0)
            {
                y = rand.Next(100) + 1;
                return Judge(x, y);
            }
            else
            {
                return y;
            }
        }

        public static string Solve(string expression)
        {
            DataTable dt = new DataTable();
            string result = dt.Compute(expression, null).ToString();//用compute函数进行算式运算
            return result;
        }

        static void Main(string[] args)
        {
            

            Console.WriteLine("请输入需要的运算题目数量：(不可为0或者负数)");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string suanshi = Create();//生成算式
                string answer = Solve(suanshi);//得出答案
                string formual = suanshi + "=" + answer +"\n";
                if(int.Parse(answer)>=0)
                {
                    Console.Write(formual);
                   File.AppendAllText(@"C:/study.txt", formual+"\r\n");
                }
                else
                {
                    i--;
                }
            }
        }


    }
}

