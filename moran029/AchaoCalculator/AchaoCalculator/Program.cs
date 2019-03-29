using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchaoCalculator
{

    class Math
    {
        public Random r = new Random();//得到伪随机数
        public string getM()//得到随机符号
        {
            string mark = "0";
            int mark1;
            mark1 = r.Next(1, 5);
            switch (mark1)
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
        public int getQ()//得到算式中数字随机个数
        {
            int quantity;
            quantity = r.Next(2, 4);
            return quantity;
        }
        public int getN()//得到随机大小的数字
        {
            int num;
            num = r.Next(1, 101);
            return num;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int s;
            Console.Write("请输入需要几组算式：");
            s = int.Parse(Console.ReadLine());
            Math a = new Math();
            for (int i = 0; i < s;)
            {
                int q = a.getQ();
                if (q == 2)
                {
                    string m = a.getM();
                    int n1 = a.getN();
                    int n2 = a.getN();
                    switch (m)
                    {
                        case "+":
                            {
                                int answer = n1 + n2;
                                Console.WriteLine(n1 + m + n2 + "=" + answer);
                                i++;
                                break;
                            }
                        case "-":
                            {
                                int answer = n1 - n2;
                                if (answer < 0)
                                    break;
                                else
                                {
                                    Console.WriteLine(n1 + m + n2 + "=" + answer);
                                    i++;
                                    break;
                                }
                            }
                        case "*":
                            {
                                int answer = n1 * n2;
                                Console.WriteLine(n1 + m + n2 + "=" + answer);
                                i++;
                                break;
                            }
                        case "/":
                            {
                                if (Convert.ToDouble(n1) % Convert.ToDouble(n2) == 0)
                                {
                                    int answer = n1 / n2;
                                    Console.WriteLine(n1 + m + n2 + "=" + answer);
                                    i++;
                                    break;
                                }
                                else
                                    break;
                            }
                    }
                }
                else
                {
                    int temp = 0;
                    string m1 = a.getM();
                    string m2 = a.getM();
                    int n1 = a.getN();
                    int n2 = a.getN();
                    int n3 = a.getN();
                    int b = 0;
                    switch (m1)
                    {
                        case "+":
                            {
                                b = n1 + n2;
                                break;
                            }
                        case "-":
                            {
                                b = n1 - n2;
                                if (b < 0)
                                {
                                    temp = 1;
                                    break;
                                }
                                else
                                    break;
                            }
                        case "*":
                            {
                                b = n1 * n2;
                                break;
                            }
                        case "/":
                            {
                                if (Convert.ToDouble(n1) % Convert.ToDouble(n2) == 0)
                                {
                                    b = n1 / n2;
                                    break;
                                }
                                else
                                {
                                    temp = 1;
                                    break;
                                }
                            }
                    }
                    if (temp == 0)
                    {
                        switch (m2)
                        {
                            case "+":
                                {
                                    int answer = b + n3;
                                    Console.WriteLine("(" + n1 + m1 + n2 + ")" + m2 + n3 + "=" + answer);
                                    i++;
                                    break;
                                }
                            case "-":
                                {
                                    int answer = b - n3;
                                    if (answer < 0)
                                        break;
                                    else
                                    {
                                        Console.WriteLine("(" + n1 + m1 + n2 + ")" + m2 + n3 + "=" + answer);
                                        i++;
                                        break;
                                    }
                                }
                            case "*":
                                {
                                    int answer = b * n3;
                                    Console.WriteLine("(" + n1 + m1 + n2 + ")" + m2 + n3 + "=" + answer);
                                    i++;
                                    break;
                                }
                            case "/":
                                {
                                    if (Convert.ToDouble(b) % Convert.ToDouble(n3) == 0)
                                    {
                                        int answer = n1 / n2;
                                        Console.WriteLine("(" + n1 + m1 + n2 + ")" + m2 + n3 + "=" + answer);
                                        i++;
                                        break;
                                    }
                                    else
                                        break;
                                }
                        }
                    }
                }
            }
        }
    }
}

