using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("请输入要生成的题数：");
            int n = int.Parse(Console.ReadLine());
            int[] temp = new int[101];
            Random r = new Random();

            for (int number = 0; number < 101; number++)
            {
                temp[number] = r.Next(1, 101);
            }

            for (int i = 1; i <= n; i++)
            {
                int a = r.Next(2, 4);
                int[] num = new int[a];
                for (int j = 0; j < a; j++)
                {
                    num[j] = temp[r.Next(0, 101)];
                }
                int t = r.Next(1, 5);
                int sum = ari2(t, num);;
                if (a == 2)
                {
                    Console.WriteLine(" = " + sum);
                }
                else
                {
                    int t1 = r.Next(1, 5);
                    ari3(t1, t, num, sum);
                }
            }
        }
        public static int ari2(int t, int[] num)
        {
            while (true)
            {
                int sub = num[0] - num[1];
                int sub1 = num[1] - num[0];
                int div = num[0] / num[1];
                int div1 = num[1] / num[0];
                int rea = num[0] % num[1];
                int rea1 = num[1] % num[0];
                if (t == 1)
                {
                    Console.Write(num[0] + " + " + num[1]);
                    return num[0] + num[1];
                }
                else if (t == 2)
                {
                    if (sub < 0)
                    {
                        Console.Write(num[1] + " - " + num[0]);
                        return sub1;
                    }
                    else
                    {
                        Console.Write(num[0] + " - " + num[1]);
                        return sub;
                    }
                }
                else if (t == 3)
                {
                    Console.Write(num[0] + " * " + num[1]);
                    return num[0] * num[1];
                }
                else
                {
                    if (rea == 0)
                    {
                        Console.Write(num[0] + " / " + num[1]);
                        return div;
                    }
                    else if (rea1 == 0)
                    {
                        Console.Write(num[1] + " / " + num[0]);
                        return div1;
                    }
                    else
                    {
                        t--;
                        continue;
                    }
                }
            }
        }

        public static int ari3(int t1, int t, int[] num, int sum)
        {
            while (true)
            {
                if (t1 == 1)
                {
                    Console.WriteLine(" + " + num[2] + " = " + (sum+num[2]));
                    return sum + num[2];
                }
                else if (t1 == 2)
                {
                    if (sum - num[2] < 0)
                    {
                        t1--;
                    }
                    else
                    {
                        Console.WriteLine(" - " + num[2] + " = " + (sum-num[2]));
                        return sum - num[2];
                    }
                }
                else if (t1 == 3)
                {
                    if (t == 2 && (num[0]-num[1]*num[2]) < 0)
                    {
                        t1--;
                    }
                    else if(t == 1)
                    {
                        Console.WriteLine(" * " + num[2] + " = " + (num[0]+num[1]*num[2]));
                        return num[0] + num[1] * num[2];
                    }
                    else if(t == 2)
                    {
                        Console.WriteLine(" * " + num[2] + " = " + (num[0] - num[1] * num[2]));
                        return num[0] - num[1] * num[2];
                    }
                    else
                    {
                        Console.WriteLine(" * " + num[2] + " = " + (sum * num[2]));
                        return sum * num[2];
                    }
                }
                else
                {
                    if (t == 2 && (num[0] - num[1] / num[2]) < 0)
                    {
                        t1--;
                    }
                    else if(t == 3 && (sum % num[2]) == 0)
                    {
                        Console.WriteLine(" / " + num[2] + " = " + (sum/num[2]));
                        return sum / num[2];
                    }
                    else if(t==1 && num[1]%num[2]==0)
                    {
                        Console.WriteLine(" / " + num[2] + " = " + (num[0] + num[1] / num[2]));
                        return num[0] + num[1] / num[2];
                    }
                    else if(t==2 && num[1]%num[2]==0)
                    {
                        Console.WriteLine(" / " + num[2] + " = " + (num[0] - num[1] / num[2]));
                        return num[0] - num[1] / num[2];
                    }
                    else
                    {
                        t1--;
                    }
                }
            }
        }
    }
}
