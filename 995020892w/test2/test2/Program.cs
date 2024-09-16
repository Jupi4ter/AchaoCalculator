using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        public int getNum(int[] Numx, int temp, int min, int max, Random x)
        {
            int n = 0;
            while (n <= Numx.Length - 1)
            {
                if (Numx[n] == temp)
                {
                    temp = x.Next(min, max);
                    getNum(Numx, temp, min, max, x);            //递归
                }
                n++;
            }
            return temp;
        }
        public int[] getRandomNum(int num, int min, int max)
        {
            Random x = new Random(unchecked((int)DateTime.Now.Ticks));
            int[] Numx = new int[num];
            int temp = 0;
            for (int i = 0; i <= num - 1; i++)
            {
                temp = x.Next(min, max);                   //随机取数
                Numx[i] = getNum(Numx, temp, min, max, x);
            }
            return Numx;
        }
        public void test()
        {
            int num1, temp1;
            int[] x = getRandomNum(5, 1, 100);            //取随机数
            int[] a = new int[1];
            char[] b = new char[2];
            string pro;
            num1 = x[3] % 3;
            switch (num1)
            {
                case 0:
                    a[0] = x[0] + x[1];
                    b[0] = '+';
                    break;
                case 1:
                    if (x[0] < x[1])                  //排除负数结果
                    {
                        temp1 = x[0];
                        x[0] = x[1];
                        x[1] = x[0];
                    }
                    a[0] = x[0] - x[1];
                    b[0] = '-';
                    break;
                case 2:
                    if (x[0] % x[1] == 0)      //判断是否可以整除
                    {
                        a[0] = x[0] / x[1];
                        b[0] = '/';
                    }
                    else
                    {
                        a[0] = x[0] * x[1];
                        b[0] = '*';
                    }
                    break;
                default:
                    break;
            }
            num1 = x[4] % 2;//第二个操作符
            switch (num1)
            {
                case 0:
                    b[1] = '+';
                    a[0] += x[2];
                    break;
                case 1:
                    if (b[0] < x[2])//排除负数结果
                    {
                        b[1] = '+';
                        a[0] += x[2];
                    }
                    else
                    {
                        b[1] = '-';
                        a[0] -= x[2];
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine("{0}{1}{2}{3}{4}=", x[0], b[0], x[1], b[1], x[2]);
            pro = Convert.ToString(x[0]) + Convert.ToString(a[0]) + Convert.ToString(x[1]) + Convert.ToString(b[1]) + Convert.ToString(x[2]) + "=" + Convert.ToString(a[0]);
            PutFile(pro);
        }
        public void PutFile(string x)//将算式打印到文件中
        {
            string path = @"D:\subject.txt";
            FileInfo fileInfo = new FileInfo(path);
            StreamWriter sw = fileInfo.AppendText();
            sw.WriteLine(x);
            sw.Close();
        }
        static void Main(string[] args)
        {

            Program A = new Program();
            int n, i;
            Console.WriteLine("请输入题目个数：");
            n = Convert.ToInt32(Console.ReadLine());//题目个数
            for (i = 0; i < n; i++)
            {
                A.test();
            }
        }
    }
}
