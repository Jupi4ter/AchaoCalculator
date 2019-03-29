using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace calculator
{
    public class aSign
    {
        public static string Sign(int a)
        {
            switch (a)
            {
                case 1:
                    return "+";
                case 2:
                    return "-";
                case 3:
                    return "*";
                case 4:
                    return "/";
            }
            return ".";
        }
    }
    class Program
    {

        static int Result(int a, int b, int type)
        {
            switch (type)
            {
                case 1:
                    return a + b;
                case 2:
                    return a - b;
                case 3:
                    return a * b;
                case 4:
                    return a / b;
            }
            return type;
        }
        static void Main(string[] args)
        {
            //生成的 n 道练习题及其对应的正确答案输出到一个文件 subject.txt 中
            Console.WriteLine("请输入题目数量：");
            int input = Convert.ToInt32(Console.ReadLine());
            int i;
            int[] num1 = new int[4];
            List<int> store = new List<int>();

            int sign1 = 0, sign2 = 0;
            Random x = new Random();

            string fileName = @"D:\calculate.txt";
            StreamWriter sw = new StreamWriter(fileName);
            for (i = 0; i < input; i++)
            {
                num1[0] = x.Next(0, 101);
                num1[1] = x.Next(0, 101);
                num1[2] = x.Next(0, 101);
                sign1 = x.Next(1, 5);
                sign2 = x.Next(1, 5);
                if (sign1 == 4)
                {
                    while (num1[0] % num1[1] != 0)
                    {
                        num1[0] = x.Next(0, 101);
                        num1[1] = x.Next(1, 101);

                    }

                }
                if (sign2 == 4)
                {
                    while (num1[1] % num1[2] != 0)
                    {
                        num1[2] = x.Next(1, 101);
                    }
                }



                store.Add(Result(Result((num1[0]), num1[1], sign1), num1[2], sign2));
                Console.WriteLine(num1[0] + aSign.Sign(sign1) + num1[1] + aSign.Sign(sign2) + num1[2] + "=");
                sw.WriteLine(num1[0] + aSign.Sign(sign1) + num1[1] + aSign.Sign(sign2) + num1[2] + "=");
                sw.Flush();
            }
            Console.WriteLine("输入Y打印答案");
            string w = Console.ReadLine();
            if (w == "Y")
            {
                for (int k = 0; k < input; k++)
                {
                    Console.WriteLine(k + 1 + "、" + store[k]);
                    sw.WriteLine(k + 1 + "、" + store[k]);
                    sw.Flush();
                }
            }

        }
    }
}
