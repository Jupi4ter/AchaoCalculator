using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    //生成n个式子的op_num*n个运算符
    public class Operator
    {
        public string[] Operators(int op_num,int n)
        {
            Random random = new Random();
            string[] operators = new string[n];
            int op_type1, op_type2;
            op_type1 = random.Next(1, 5);//生成1-6自然数，1-2分别表示+-,4-5分别表示*/,
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < op_num; i++)
                {
                    switch (op_type1)
                    {
                        case 1:
                            {
                                operators[j] += "+";
                                break;
                            }
                        case 2:
                            {
                                operators[j] += "-";
                                break;
                            }
                        case 3:
                            {
                                operators[j] += "*";
                                break;
                            }
                        case 4:
                            {
                                operators[j] += "/";
                                break;
                            }
                    }
                    op_type2 = random.Next(1, 5);
                    while ((op_type1 == op_type2) || (Math.Abs(op_type2 - op_type1) < 2)) op_type2 = random.Next(1, 5);
                    op_type1 = op_type2;
                }
                
            }
            return operators;
        }
    }

    //判断是否为质数
    public class IsPrime
    {
        public bool isPrime(long num)
        {
            if (num < 2)
                return false;
            if (num == 2 || num == 3)
            {
                return true;
            }
            if (num % 6 != 1 && num % 6 != 5)
            {
                return false;
            }
            int sqr = (int)Math.Sqrt(num);
            for (int i = 5; i <= sqr; i += 6)
            {
                if (num % i == 0 || num % (i + 2) == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }

    //生成四则表达式
    public class Expressions
    {
        public string[] Epression(int n)
        {
            String[] str = new string[n];//存放n个表达式
            Random random = new Random();
            IsPrime isprime = new IsPrime();
            int num1, num2;
            int op_num = random.Next(2, 4);//随机产生运算符的个数
            Operator operators = new Operator();
            String[] ops = new string[n];
            ops = operators.Operators(op_num, n);
            int i, j;
            //生成四则表达式
            for (i = 0; i < n; i++)
            {
                num1 = random.Next(0, 101);//随机产生0-100的数
                while (isprime.isPrime(num1)) num1 = random.Next(0, 101);
                str[i] += num1;
                for (j = 0; j < op_num; j++)
                {
                    str[i] += ops[i][j];
                    num2 = random.Next(0, 101);//随机产生0-100的数
                    if (ops[i][j] == '/')
                    {
                        while ((num1 == 0 || num2 == 0) || (num1 % num2 != 0)) num2 = random.Next(0, 101);
                    }
                    num1 = num2;
                    str[i] += num1;
                }

            }
            return str;
        }
    }

    //显示答案
    public class Answer
    {
        public void questions(string[] str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                Console.WriteLine();
                Console.Write("{0}、", i + 1);
                Console.Write(str[i]);
                Console.WriteLine("=");
            }
            Console.WriteLine();
        }
        public void answers(string[] str)
        {

            DataTable table = new DataTable();

            for (int i = 0; i < str.Length; i++)
            {
                Console.WriteLine();
                Console.Write("{0}、", i + 1);
                Console.Write(str[i]);
                Console.Write("=");
                string temp = table.Compute(str[i], "").ToString();
                Console.WriteLine(temp);
            }
            Console.WriteLine();
        }
    }
    //保存文件
    public class Save
    {
        public void saves(string[] str)
        {
            DataTable table = new DataTable();
            StreamWriter sw = File.AppendText(@"E:\\subject.txt"); //保存到指定路径
            for (int i=0;i<str.Length;i++)
            {
                sw.Write("\r\n");
                sw.Write("{0}"+"、"+str[i]+"=",i+1);
                sw.Write("\r\n");
            }
            sw.Write("\r\n \r\n \r\n \r\n ");
            sw.Write("-------------------------------------------------------------------------------------------------------");
            sw.Write("\r\n \r\n \r\n \r\n ");
            for (int i = 0; i < str.Length; i++)
            {
                sw.Write("\r\n");
                string temp = table.Compute(str[i], "").ToString();
                sw.Write("{0}" + "、" + str[i] + "="+temp, i + 1);
                sw.Write("\r\n");
            }
            sw.Flush();
            sw.Close();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Expressions expressions = new Expressions();
            Answer answer = new Answer();
            Console.WriteLine("请输入四则运算式个数n：");
            int n = Int32.Parse(Console.ReadLine());
            string[] exps = expressions.Epression(n);
            answer.questions(exps);
            Console.WriteLine("按任意键查看答案！");
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("答案见下：");
            Console.WriteLine();
            answer.answers(exps);
            Save save = new Save();
            Console.WriteLine("是否保存？（是输入：1,否输入：0）");
            int sf = int.Parse(Console.ReadLine());
            if (sf == 1)
            {
                save.saves(exps);
                Console.WriteLine("保存成功！");
            }
        }
    }
}
