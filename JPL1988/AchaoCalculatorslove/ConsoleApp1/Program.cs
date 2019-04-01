using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class wuyu
    {
        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Calculation(10000000);
        }
    }
    public class Program
    {
        StringBuilder lastresult = new StringBuilder();
        caculator caculators = new caculator();
        private Random random = new Random();
        public void Calculation(int n)
        {
            for (int i = 0; i < n; i++)
            {
                int sign = random.Next(2, 3);              
                if (sign == 2)
                    Calculation2();
                else
                    Calculation3();
            }
            System.IO.File.WriteAllText("D://homework.txt",lastresult.ToString(),Encoding.Default);

        }
        private void Calculation3()
        {
            string[] s = new string[5];
            int d = random.Next(1, 101);
            char z = getchar();
            StringBuilder str = two(s);
            str.Append(z);
            str.Append(d);
            int result = caculators.compute(s);
            if (result == -1)
                Calculation3();
            else
            {
                str.Append('=');
                str.Append(result);
                str.Append(' ');
                lastresult.Append(str);
            }           
        }
        public void Calculation2()
        {
            string[] s = new string[5];
            StringBuilder str = two(s);
            int result =caculators.compute(s);
            if (result == -1)
                Calculation2();
            else
            {
                str.Append('=');
                str.Append(result);
                str.Append(' ');
                lastresult.Append(str);
            }           
        }

        private char getchar()
        {
            Char res = '+';
            int x = random.Next(0, 4);
            switch (x)
            {
                case 1:
                    break;
                case 2:
                    res = '-';
                    break;
                case 3:
                    res = '*';
                    break;
                default:
                    res = '/';
                    break;
            }
            return res;
        }       
        public StringBuilder two(string[] strings)
        {
            int a = random.Next(1, 101);
            int b = random.Next(1, 101);
            int c = random.Next(1, 101);
            char x = getchar();
            char y = getchar();
            StringBuilder str = new StringBuilder();
            strings[0] = a.ToString();
            strings[1] = x.ToString();
            strings[2] = b.ToString();
            strings[3] = y.ToString();
            strings[4] = c.ToString();
            str.Append(a);
            str.Append(x);
            str.Append(b);
            str.Append(y);
            str.Append(c);
            return str;
        }
    }

    public class caculator
    {
        private static string Operator = "+-*/";
        Queue<string> postfix;//队列储存后缀表达式
        Stack<string> stack;//栈储存计算后缀表达式时的数字
        public int compute(string[] s)
        {
            convert(s);//计算后缀表达式
            stack = new Stack<string>(7);
            int symbol;
            int length = postfix.Count;
            for (int i = 0; i < length; i++)
            {
                symbol = isOperator(postfix.Peek());
                if (symbol > -1)//是否为操作符
                {
                    postfix.Dequeue();//把操作符从队列里面移除
                    int d2 = int.Parse(stack.Pop());
                    int d1 = int.Parse(stack.Pop());//取出数据进行计算
                    int d3 = 0;
                    switch (symbol)
                    {
                        case 0:
                            d3 = d1 + d2;
                            break;
                        case 1://排除负数结果
                            d3 = d1 - d2;
                            if (d3 < 0)
                                return -1;
                            break;
                        case 2:
                            d3 = d1 * d2;
                            break;
                        case 3://排除小数结果
                            d3 = d1 / d2;
                            if (d3 * d2 != d1)
                                return -1;
                            break;
                    }
                    stack.Push(d3.ToString());//将计算结果压入数字栈
                }
                else
                {
                    stack.Push(postfix.Dequeue());//将数字压入数字栈
                }
            }
            return int.Parse(stack.Pop());//返回最终结果
        }


        public void convert(string[] strings)
        {
            postfix = new Queue<string>(strings.Length);
            stack = new Stack<string>(7);
            for (int i = 0; i < strings.Length; i++)
            {
                String tempc = strings[i];
                if (i % 2 == 1)//说明是操作符
                {
                    if (stack.Count == 0)//栈为空则将数据直接压入计算符栈
                    {
                        stack.Push(tempc);
                    }
                    else
                    {//栈不为空则和栈顶符号的优先级比较，将比当前优先级高的符号移除，并加进后缀表达式
                        while (stack.Count != 0 && priority(tempc, stack.Peek()))
                        {
                            postfix.Enqueue(stack.Pop());
                        }
                        stack.Push(tempc);//将当前符号压入栈顶
                    }
                }
                else
                {
                    postfix.Enqueue(tempc);//若是数字则直接加进后缀表达式
                }
            }
            while (stack.Count > 0)
            {
                postfix.Enqueue(stack.Pop());//将剩余操作符加进后缀表达式
            }
        }

        public int isOperator(string c)
        {
            return Operator.IndexOf(c);
        }

        public bool priority(String o1, String o2)
        {
            return getPriority(o1) <= getPriority(o2);
        }

        public int getPriority(String c)
        {
            switch (c)
            {
                case "+":
                case "-":
                    return 1;
                default:
                    return 2;
            }
        }
    }
}
