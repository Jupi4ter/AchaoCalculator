using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haveadate
{
    /// <summary>
    /// 在此讨论有几个类？
    /// 1.操作数类，产生一个符合要求的操作数类
    /// 2.验算结果是否为小数
    /// 3.待讨论
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string[] oper = { "+", "-", "*", "/" };
            int n;//出多少道题
            Console.WriteLine("请问今天出多少道题，boss？");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("收到，题库如下，答案见文件 subject.txt 喔  >_< ");        
            string question = "";
            //随机类对象
            _random random = new _random();
            //四则运算对象
            Compute compute;
            //运算结果
            float res;
            for(int i = 0; i < n; i++)
            {
                question = "";
                float num;
                int _operator;
                for (int j = 0; j < random.return_num(); j++)
                {
                    //储存操作数和操作符代号
                    num = random.return_operand();
                    _operator = random.return_operator();                    
                    question += num;
                    switch (_operator)
                    {
                        case 0:
                            question += oper[0];
                            break;
                        case 1:
                            question += oper[1];
                            break;
                        case 2:
                            question += oper[2];
                            break;
                        case 3:
                            question += oper[3];
                            break;
                    }
                }
                num = random.return_operand();
                question += num;
                compute = new Compute(question);
                res = compute.run();
                //若结果不为整数，此次操作无效
                if (Math.Abs(res - (int)res) != 0)
                {
                    i--;
                    continue;
                }
                question += "=";
                question += res;
                Console.WriteLine(question);
            }         
            Console.ReadKey();
        }
    }
    //产生随机数
    public class _random
    {
        //随机数对象
        Random random = new Random();
        //构造函数
        public _random()
        {

        }
        //返回操作数（0-100）
        public float return_operand()
        {
            return (float) random.Next(0, 101);
        }
        //返回一道题中有几个运算符（2-3）
        public int return_num()
        {
            return random.Next(2, 4);
        }
        //返回运算符数组对应的下标
        public int return_operator()
        {
            return random.Next(0, 4);
        }
    }
    //四则运算类，栈的运用
    public class Compute
    {
        public static char[] str = new char[100];
        private static char[] temp;
        //操作数栈
        Stack<float> num = new Stack<float>();
        //符号栈
        Stack<char> ch = new Stack<char>();
        public Compute(string question)
        {
            //初始化
            //num.Clear();
            //ch.Clear();
            temp = question.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {               
               if(i < temp.Length)
                {
                    str[i] = temp[i];
                }
                else
                {
                    str[i] = '\0';
                }
            }           
        }
        //权重判断方法
        public int Priority(char s)
        {
            switch (s)
            {
                case '(':
                    return 3;
                case '*':
                case '/':
                    return 2;
                case '+':
                case '-':
                    return 1;
                default:
                    return 0;
            }
        }
        public float run()
        {
            int i = 0;
            float tmp = 0, j;
            while (str[i] != '\0' || ch.Count != 0)
            {
                if (str[i] >= '0' && str[i] <= '9')
                {
                    tmp = tmp * 10 + str[i] - '0';
                    i++;
                    if (str[i] < '0' || str[i] > '9')
                    {
                        num.Push(tmp);
                        tmp = 0;
                    }
                }
                else
                {
                    if (str[i] != '\0' && ((num.Count != 0) || (Priority(str[i]) > Priority(ch.Peek()))))
                    {
                        ch.Push(str[i]);
                        i++;
                        continue;
                    }
                   
                    if ((str[i] == '\0' && ch.Count != 0) || Priority(str[i]) <= Priority(ch.Peek()))
                    {
                        switch (ch.Pop())
                        {
                            case '+':
                                num.Push(num.Pop() + num.Pop());
                                break;
                            case '-':
                                j = num.Pop();
                                num.Push(num.Pop() - j);
                                break;
                            case '*':
                                num.Push(num.Pop() * num.Pop());
                                break;
                            case '/':
                                j = num.Pop();
                                num.Push(num.Pop() / j);
                                break;
                        }
                        continue;
                    }

                }
            }
            return num.Pop();
        }
    }
}
