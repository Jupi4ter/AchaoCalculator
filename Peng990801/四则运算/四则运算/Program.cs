using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 四则运算
{
    class Program
    {
        static void Main(string[] args)
        {
            mathvoid op = new mathvoid();
            string A;
            do
            {
                Console.WriteLine("-------------------------------四则运算-------------------------");
                Console.WriteLine();
                Console.WriteLine("请选择您使用的运算方法:1.加法 2.减法 3.乘法 4.除法 5.退出！");
                A = Console.ReadLine();
                switch (A)
                {
                    case "1":
                        op.add();
                        continue;
                    case "2":
                        op.sub();
                        continue;
                    case "3":
                        op.mul();
                        continue;
                    case "4":
                        op.div();
                        continue;
                    case "5":
                        op.result();
                        break;
                    default:
                        Console.WriteLine("输入无效！");
                        continue;
                }
                break;
            }
            while (true);
        }
    }
    public class mathvoid
    {
        public static int right = 0;//正确数  
        public static int wrong = 0;//错误数

        public void add()//加法
        {
            int a, b;
            int result;
            Random rd = new Random();
            a = rd.Next(0, 101);
            b = rd.Next(0, 101);
            Console.WriteLine("请计算：{0}+{1}=？", a, b);
            result = Convert.ToInt32(Console.ReadLine());
            if (result == a + b)
            {
                Console.WriteLine("回答正确！");
                right++;
            }
            else
            {
                Console.WriteLine("错误，继续努力！");
                wrong++;
            }

        }
        public void sub()//减法
        {
            int a, b;
            int result;
            Random rd = new Random();
            a = rd.Next(0, 101);
            b = rd.Next(0, 101);
            Console.WriteLine("请计算：{0}-{1}=？", a, b);
            result = Convert.ToInt32(Console.ReadLine());
            if (result == a - b)
            {
                Console.WriteLine("回答正确！");
                right++;
            }
            else
            {
                Console.WriteLine("错误，继续努力！");
                wrong++;
            }
        }
        public void mul()//乘法
        {
            int a, b;
            int result;
            Random rd = new Random();
            a = rd.Next(0, 101);
            b = rd.Next(0, 101);
            Console.WriteLine("请计算：{0}*{1}=？", a, b);
            result = Convert.ToInt32(Console.ReadLine());
            if (result == a * b)
            {
                Console.WriteLine("回答正确！");
                right++;
            }
            else
            {
                Console.WriteLine("错误，继续努力！");
                wrong++;
            }


        }
        public void div()//除法
        {
            int a, b;
            int result;
            Random rd = new Random();
            a = rd.Next(0, 101);
            b = rd.Next(0, 101);
            if (b != 0)
            {
                Console.WriteLine("请计算：{0}/{1}=？", a, b);
                result = Convert.ToInt32(Console.ReadLine());
                if (result == a / b)
                {
                    Console.WriteLine("回答正确！");
                    right++;
                }
                else
                {
                    Console.WriteLine("错误，继续努力！");
                    wrong++;
                }

            }
            else
            {
                if (a != 0)
                {
                    Console.WriteLine("请计算：{0}/{1}=？", b, a);
                    result = Convert.ToInt32(Console.ReadLine());
                    if (result == b / a)
                    {
                        Console.WriteLine("回答正确！");
                        right++;
                    }
                    else
                    {
                        Console.WriteLine("错误，继续努力！");
                        wrong++;
                    }
                }
            }
        }
        public void result()                                  //统计结果！
        {
            Console.WriteLine("总共做了{0}道题：你做对了{1}道题，做错了{2}道题。", right + wrong, right, wrong);
            Console.ReadKey();
        }
    }

}
