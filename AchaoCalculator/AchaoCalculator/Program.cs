using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchaoCalculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            var seed = Guid.NewGuid().GetHashCode();
            Console.Write("请输入要生成的题数：");
            int n = int.Parse(Console.ReadLine());
            Random rd = new Random(seed);//避免随机数相同
            for (int i = 1; i <= n; i++)
            {
                int Nodi= 3;//参与计算的数字个数
                int[] num = new int[Nodi];
                for (int j = 0; j < Nodi; j++)
                {
                    num[j] = rd.Next(1, 101);
                }
                int Maths = rd.Next(1, 5);//用随机数一到四来确定运算符
                int sum = calf(Maths, num);
                int symbol = rd.Next(1, 5);
                cals(symbol, Maths, num, sum);
            }
            Console.ReadKey();
        }
        public static int calf(int M, int[] num)//前两个数的运算
        {
            int temp;
            Random rdt = new Random();
            while (true)
            {
                int sub = num[0] - num[1];
                int div = num[0] / num[1];
                if (M == 1)
                {
                    Console.Write(num[0] + " + " + num[1]);
                    return num[0] + num[1];
                }
                else if (M == 2)
                {
                    if (sub < 0)
                    {
                        temp = num[0];
                        num[0] = num[1];
                        num[1] = temp;
                    }
                    Console.Write(num[0] + " - " + num[1]);
                    return num[0]-num[1];
                }
                else if (M == 3)
                {
                    Console.Write(num[0] + " * " + num[1]);
                    return num[0] * num[1];
                }
                else
                {
                    if (num[0] < num[1])
                    {
                        temp = num[0];
                        num[0] = num[1];
                        num[1] = temp;
                    }
                    if (num[0] % num[1] == 0)
                    {
                        Console.Write(num[0] + " / " + num[1]);
                        return div;
                    }
                    else
                    {
                        M = rdt.Next(1, 5);
                        continue;
                    }
                }
            }
        }
        public static int cals(int S, int M, int[] num, int sum)//第三个数字参与运算
        {
            Random rdt = new Random();
            while (true)
            {
                if (S == 1)
                {
                    Console.WriteLine(" + " + num[2] + " = " + (sum + num[2]));
                    return sum + num[2];
                }
                else if (S == 2)
                {
                    if (sum - num[2] < 0)
                    {
                        S=rdt.Next(1,5);
                        continue;
                    }
                    Console.WriteLine(" - " + num[2] + " = " + (sum - num[2]));
                    return sum - num[2];
                }
                else if (S == 3)
                {
                    if (M == 2 && (num[0] - num[1] * num[2]) < 0)
                    {
                        S = rdt.Next(1, 5);
                    }
                    else if (M == 1)
                    {
                        Console.WriteLine(" * " + num[2] + " = " + (num[0] + num[1] * num[2]));
                        return num[0] + num[1] * num[2];
                    }
                    else if (M == 2)
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
                    if (M == 2 && (num[0] - num[1] / num[2]) < 0)
                    {
                        S = rdt.Next(1, 5);
                    }
                    else if (M == 3 && (sum % num[2]) == 0)
                    {
                        Console.WriteLine(" / " + num[2] + " = " + (sum / num[2]));
                        return sum / num[2];
                    }
                    else if (M == 1 && num[1] % num[2] == 0)
                    {
                        Console.WriteLine(" / " + num[2] + " = " + (num[0] + num[1] / num[2]));
                        return num[0] + num[1] / num[2];
                    }
                    else if (M == 2 && num[1] % num[2] == 0)
                    {
                        Console.WriteLine(" / " + num[2] + " = " + (num[0] - num[1] / num[2]));
                        return num[0] - num[1] / num[2];
                    }
                    else
                    {
                        S = rdt.Next(1, 5);
                    }
                }
            }
        }
    }
}
