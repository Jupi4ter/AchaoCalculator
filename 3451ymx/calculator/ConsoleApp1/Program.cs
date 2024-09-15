using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
      
            Random rd = new Random();
            List<int> num = new List<int>();//存储作运算的数字
            List<string> opt = new List<string>();//存储每道题的运算符
            int i = 0;
            Console.Write("请输入题目数量：");
            int n =Convert.ToInt32(Console.ReadLine());
            for (int j = 0; j < 3*n; j++)//产生3n个数和运算符
            {
                num.Add(rd.Next(1, 101));
                opt.Add(Operation_character(rd.Next(1, 5)));
            }
            
            for (int x = 1; x <= n; x++)//产生n道题
            {
                Console.Write(x);
                Judge1(num[i], num[i + 1], num[i + 2], opt[i], opt[i + 1]);
                i = i + 3;
                /*
                int temp = rd.Next(2, 4);//每道题需要计算的数字的个数
                if (temp == 3)
                {
                    Console.Write(x);
                    Judge1(num[i] , num[i + 1], num[i + 2], opt[i], opt[i + 1]);
                    i = i + 3;
                }
                else
                {
                    Console.Write(x);
                    Judge2(num[i] , num[i + 1], num[i + 2], num[i + 3], opt[i], opt[i + 1], opt[i + 2]);
                    i = i + 4;
                }
                */
            }
        }
        

        static string Operation_character(int opt)//待选运算符
        {
            switch (opt)
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
            return "";
        }

        static void Judge1(int a, int b, int c, string i, string j)
        {
            if (i == "/" && j == "/")
            {
                if(a<b&&b<c)
                {
                    i = "+";
                    j = "+";
                }
                else 
                {
                    i = "+";
                    j = "-";
                }
            }
            else if (i == "/")
            {
                while (a % b != 0 ||a==b )
                {
                    b--;
                    if(b==1)
                    {
                        i = "+";
                        b = 4*b + c;
                    }
                }
            }
            else if (j == "/")
            {
                while (b % c != 0 || b==c)
                {
                    c--;
                    if (c == 1)
                    {
                        j = "+";
                        c = a - 5*c;
                    }
                }
            }
            Console.Write( ".   " + a + i + b + j + c + "=");
            if (i == "+" && j == "+")
                Console.WriteLine( a + b + c);
            else if(i == "+" && j == "-")
                Console.WriteLine(a + b - c);
            else if (i == "+" && j == "*")
                Console.WriteLine(a + b * c);
            else if (i == "+" && j == "/")
                Console.WriteLine(a + b / c);
            else if (i == "-" && j == "+")
                Console.WriteLine(a - b + c);
            else if (i == "-" && j == "-")
                Console.WriteLine(a - b - c);
            else if (i == "-" && j == "*")
                Console.WriteLine(a - b * c);
            else if (i == "-" && j == "/")
                Console.WriteLine(a - b / c);
            else if (i == "*" && j == "+")
                Console.WriteLine(a * b + c);
            else if (i == "*" && j == "-")
                Console.WriteLine(a * b - c);
            else if (i == "*" && j == "*")
                Console.WriteLine(a * b * c);
            else if (i == "*" && j == "/")
                Console.WriteLine(a * b / c);
            else if (i == "/" && j == "+")
                Console.WriteLine(a / b + c);
            else if (i == "/" && j == "-")
                Console.WriteLine(a / b - c);
            else if (i == "/" && j == "*")
                Console.WriteLine(a / b * c);
            else if (i == "/" && j == "*")
                Console.WriteLine(a / b * c);
        }
        /*
        static void Judge2(int a, int b, int c,int d, string i, string j,string k)
        {
            if(i=="/"&&j=="/"&&k=="/")
            {
                i = "+";
                j = "*";
                if (b * c % d != 0)
                    d--;
            }
            else if(i == "/" && j == "/")
            {
                if (a < b && b < c)
                {
                    i = "+";
                    j = "+";
                }
                else
                {
                    i = "+";
                    j = "-";
                }
            }
            else if (j == "/" && k == "/")
            {
                if (b < c && c < d)
                {
                    j = "+";
                    k = "+";
                }
                else
                {
                    j = "+";
                    k = "-";
                }
            }

            else if (i == "/")
            {
                while (a % b != 0)
                {
                    b--;
                }
            }
            else if (j == "/")
            {
                while (b % c != 0)
                {
                    c--;
                }
            }
            else if (k == "/")
            {
                while(c%d!=0)
                {
                    d--;
                }
            }
            Console.WriteLine( ".   " + a + i + b + j + c + k + d + "=");
        }
        */

       
    }
}
