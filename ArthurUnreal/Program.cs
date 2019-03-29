using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class PriMath
    {
        public Random random = new Random();

        public string GetMark()//得到随机符号
        {
            int mark_depond;//用于得到运算符号的数字
            string mark = "";
            mark_depond = random.Next(1, 5);
            switch (mark_depond)
            {
                case 1:
                    mark = "+";
                    break;
                case 2:
                    mark = "-";
                    break;
                case 3:
                    mark = "*";
                    break;
                case 4:
                    mark = "/";
                    break;
                default:
                    break;
            }
            return mark;
        }

        public int Getquantity()//得到随机的运算因子
        {
            int num_depond;// 用于得到判定多数运算的数字
            num_depond = random.Next(2, 4);
            return num_depond;
        }

        public int Getnum()//得到随机数
        {
            int num;
            num = random.Next(1,101);
            return num;
        }
    }

    public class Operation
    {
        private int[] quantity=new int[0];
        private int[] num= new int[3];
        public PriMath math = new PriMath();
        private int m_num;

        public Operation(int sa_num)
        {
            m_num = sa_num;
            quantity = new int[m_num];
            quantity[0] = 2;
        }

        public void GetRandom(int m_num)//得到随机数，随机符号且判断是否为整数，若为整数则输出
        {
            int i;
            for (i = 0; i < m_num; i++)
            {
                num[0] = math.Getnum();
                num[1] = math.Getnum();
                num[2] = math.Getnum();
                string Mark1 = math.GetMark();
                string Mark2 = math.GetMark();
                if (GetT_F(num[0], num[1], num[2], Mark1, Mark2,i) == -1010000)
                {
                    GetRandom(1);
                }
                else
                {
                    GetAnswer(num[0], num[1], num[2], Mark1, Mark2,GetT_F(num[0], num[1], num[2], Mark1, Mark2,i),i);
                }
            }
        }

        public int GetT_F(int num1,int num2,int num3,string mark1,string mark2,int j)//得到随机项数quantity，判断随机数计算后是否为整数
        {
            int i=0;
            quantity[j]=math.Getquantity();
            if (quantity[j] == 2)
            {
                switch (mark1)//判定函数符号
                {
                    case "+":
                        return num1 + num2;
                    case "-":
                        return num1 - num2;
                    case "*":
                        return num1 * num2;
                    case "/":
                        if (num1 * 100 / num2 % 100 != 0)
                        {
                            i = -1010000;
                            break;
                        }
                        else
                        {
                            return num1 / num2;
                        }
                }
                return i;
            }
            else
            {
                switch (mark1)
                {
                    case "+":
                        switch (mark2)
                        {
                            case "+":
                                return (num1 + num2 + num3);
                            case "-":
                                return (num1 + num2 - num3);
                            case "*":
                                return ((num1 + num2) * num3);
                            case "/":
                                if ((num1 + num2) * 200 / num3 % 200 != 0)
                                {
                                    i = -1010000;
                                    break;
                                }
                                else
                                {
                                    return ((num1 + num2) / num3);
                                }
                        }
                        break;
                    case "-":
                        switch (mark2)
                        {
                            case "+":
                                return (num1 - num2 + num3);
                            case "-":
                                return (num1 - num2 - num3);
                            case "*":
                                return ((num1 - num2) * num3);
                            case "/":
                                if ((num1 - num2) * 200 / num3 % 200 != 0)
                                {
                                    i = -1010000;
                                    break;
                                }
                                else
                                {
                                    return ((num1 - num2) / num3);
                                }
                        }
                        break;
                    case "*":
                        switch (mark2)
                        {
                            case "+":
                                return num1 * num2 + num3;
                            case "-":
                                return num1 * num2 - num3;
                            case "*":
                                return num1 * num2 * num3;
                            case "/":
                                if ((num1 * num2) * 200 / num3  % 200 != 0)
                                {
                                    i = -1010000;
                                    break;
                                }
                                else
                                {
                                    return (num1 *num2) / num3;
                                }
                        }
                        break;
                    case "/":
                        if (num1 * 200 / num2 % 200 == 0)
                        {
                            switch (mark2)
                            {
                                case "+":
                                    return num1 / num2 + num3;
                                case "-":
                                    return num1 / num2 - num3;
                                case "*":
                                    return num1 / num2 * num3;
                                case "/":
                                    if ((num1 / num2) * 200 / num3 % 200 != 0)
                                    {
                                        i = -1010000;
                                        break;
                                    }
                                    else
                                    {
                                        return (num1 / num2) / num3;
                                    }
                            }
                        }
                        else
                        {
                            i = -1010000;
                        }
                        break;
                }
                return i;
            }
        }

        public void GetAnswer(int num1,int num2,int num3,string mark1,string mark2,int answer,int i)//输出随机数
        {
            if (quantity[i]==2)
            {
                Console.WriteLine(num1 + " " + mark1 + " " + num2 + " =    ");
                Console.WriteLine("The answer =  " + answer);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("(" + num1 + " " + mark1 + " " + num2 + ") "+mark2+" "+num3+" =     ");
                Console.WriteLine("The answer =  " + answer);
                Console.WriteLine();
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)//主函数，得到式子数
        {
            int M_num;
            Console.Write("请输入需要几组运算式：");
            M_num=int.Parse(Console.ReadLine());
            Operation operation = new Operation(M_num);
            operation.GetRandom(M_num);
        }
    }
}
